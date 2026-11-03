using System;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using EverythingToolbar.App.Helpers;
using EverythingToolbar.Services;
using NLog;

namespace EverythingToolbar.Controls
{
    public partial class UpdateBanner
    {
        private Version? _latestVersion;
        private static readonly ILogger Logger = ToolbarLogger.GetLogger<UpdateBanner>();
        private readonly ISettings _settings = Ioc.Default.GetRequiredService<ISettings>();

        public UpdateBanner()
        {
            InitializeComponent();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_settings.IsUpdateNotificationsEnabled)
                    return;

                var latestVersion = await CheckForUpdateAsync();

                if (latestVersion == null || latestVersion == TryGetSkippedUpdate())
                    return;

                _latestVersion = latestVersion;
                if (FindName("Banner") is GenericBanner banner)
                {
                    banner.Text = $"{Properties.Resources.UpdateBannerText} {_latestVersion}";
                    banner.PrimaryButtonText = "立即更新";
                }
                Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to check for updates: {Message}", ex.Message);
            }
        }

        private Version? TryGetSkippedUpdate()
        {
            try
            {
                return new Version(_settings.SkippedUpdate);
            }
            catch
            {
                return null;
            }
        }

        private async void OnDownloadClicked(object sender, EventArgs e)
        {
            if (FindName("Banner") is GenericBanner banner)
            {
                banner.PrimaryButtonText = "正在下载...";
                banner.SecondaryButtonText = "";
            }

            bool success = await UpdateService.DownloadAndInstallUpdateAsync(
                progress: new Progress<double>(pct =>
                {
                    if (FindName("Banner") is GenericBanner b)
                    {
                        b.Headline = $"正在下载更新 ({pct:0}%)...";
                    }
                }),
                statusCallback: status =>
                {
                    if (FindName("Banner") is GenericBanner b)
                    {
                        b.Text = status;
                    }
                });

            if (!success && FindName("Banner") is GenericBanner failBanner)
            {
                failBanner.PrimaryButtonText = "重试更新";
                failBanner.Text = "下载更新失败，请检查网络连接后重试。";
            }
        }

        private void OnSkipUpdateClicked(object sender, EventArgs e)
        {
            if (_latestVersion != null)
            {
                _settings.SkippedUpdate = _latestVersion.ToString();
            }
            Visibility = Visibility.Collapsed;
        }

        public static Task<Version?> CheckForUpdateAsync() => UpdateService.CheckForUpdateAsync();
    }
}
