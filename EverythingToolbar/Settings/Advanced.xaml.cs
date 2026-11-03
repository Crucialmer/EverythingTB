using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using EverythingToolbar.Controls;
using EverythingToolbar.Services;

namespace EverythingToolbar.Settings
{
    [ObservableObject]
    public partial class Advanced
    {
        [ObservableProperty]
        private bool _checkingForUpdatesVisible;

        [ObservableProperty]
        private bool _downloadUpdateButtonVisible;

        [ObservableProperty]
        private string _downloadButtonText = "立即下载并安装";

        [ObservableProperty]
        private bool _noUpdatesBannerOpen;

        partial void OnNoUpdatesBannerOpenChanged(bool value)
        {
            // Setting the margin should be done using a style and trigger, but it's currently
            // hard to do while WPF UI styles are loaded as dynamic resources.
            NoUpdatesInfoBar.Margin = value ? new Thickness(0, 15, 0, 0) : new Thickness(0);
        }

        [ObservableProperty]
        private bool _isAutostartEnabled;

        partial void OnIsAutostartEnabledChanged(bool value)
        {
            _autostart.IsEnabled = value;
        }

        public ISettings Settings { get; } = Ioc.Default.GetRequiredService<ISettings>();
        private readonly IAutostart _autostart = Ioc.Default.GetRequiredService<IAutostart>();
        private readonly EverythingClientRouter _everythingClient =
            Ioc.Default.GetRequiredService<EverythingClientRouter>();

        public bool IsLauncher => Application.Current != null;

        public bool IsWindows11 => Environment.OSVersion.Version.Build >= 22000;

        public Advanced()
        {
            InitializeComponent();
            _isAutostartEnabled = _autostart.IsEnabled;
            DataContext = this;
            Settings.PropertyChanged += OnSettingsChanged;
        }

        private void OnSettingsChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ISettings.IsForceLegacySdk))
            {
                _everythingClient.SetForceLegacySdk(Settings.IsForceLegacySdk);
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Settings.PropertyChanged -= OnSettingsChanged;
            _everythingClient.SetInstanceName(Settings.InstanceName);
        }

        private async void OnCheckForUpdatesClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckingForUpdatesVisible = true;
                NoUpdatesBannerOpen = false;
                DownloadUpdateButtonVisible = false;

                Version? latestVersion = await UpdateBanner.CheckForUpdateAsync();
                CheckingForUpdatesVisible = false;

                if (latestVersion != null)
                {
                    DownloadButtonText = $"立即下载并安装 (v{latestVersion})";
                    DownloadUpdateButtonVisible = true;
                }
                else
                {
                    NoUpdatesBannerOpen = true;
                }
            }
            catch
            {
                CheckingForUpdatesVisible = false;
                NoUpdatesBannerOpen = false;
                DownloadUpdateButtonVisible = false;
            }
        }

        private async void OnDownloadUpdateClicked(object sender, RoutedEventArgs e)
        {
            if (sender is UIElement el)
            {
                el.IsEnabled = false;
            }
            DownloadButtonText = "正在连接服务器...";

            bool success = await UpdateService.DownloadAndInstallUpdateAsync(
                progress: new Progress<double>(pct =>
                {
                    DownloadButtonText = $"正在下载更新 ({pct:0}%)...";
                }),
                statusCallback: status =>
                {
                    DownloadButtonText = status;
                });

            if (!success)
            {
                if (sender is UIElement failedEl)
                {
                    failedEl.IsEnabled = true;
                }
                DownloadButtonText = "重试下载更新";
            }
        }
    }
}
