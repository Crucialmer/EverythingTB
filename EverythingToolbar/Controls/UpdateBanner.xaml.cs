using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using NLog;

namespace EverythingToolbar.Controls
{
    public partial class UpdateBanner
    {
        private Version? _latestVersion;
        private static readonly ILogger Logger = ToolbarLogger.GetLogger<UpdateBanner>();
        private static readonly HttpClient HttpClient = new();
        private static readonly string LatestReleaseApiUrl =
            "https://api.github.com/repos/Crucialmer/EverythingToolbar/releases/latest";
        private static readonly string LatestReleaseUrl = "https://github.com/Crucialmer/EverythingToolbar/releases/latest";
        private readonly ISettings _settings = Ioc.Default.GetRequiredService<ISettings>();

        static UpdateBanner()
        {
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd("EverythingToolbar");
        }

        public UpdateBanner()
        {
            InitializeComponent();
        }

        private static async Task<Version?> GetLatestStableReleaseVersion()
        {
            try
            {
                var response = await HttpClient.GetAsync(LatestReleaseApiUrl);
                if (!response.IsSuccessStatusCode)
                    return null;

                await using var jsonStream = await response.Content.ReadAsStreamAsync();
                var release = await JsonSerializer.DeserializeAsync<Release>(jsonStream);
                if (release?.TagName == null)
                    return null;

                var versionString = release.TagName.TrimStart('v', 'V');
                if (Version.TryParse(versionString, out var parsed))
                {
                    return new Version(
                        parsed.Major,
                        parsed.Minor >= 0 ? parsed.Minor : 0,
                        parsed.Build >= 0 ? parsed.Build : 0,
                        parsed.Revision >= 0 ? parsed.Revision : 0);
                }
                return null;
            }
            catch
            {
                Logger.Info("Failed to get latest release version.");
            }

            return null;
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

        private void OnDownloadClicked(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(LatestReleaseUrl) { UseShellExecute = true });
        }

        private void OnSkipUpdateClicked(object sender, EventArgs e)
        {
            if (_latestVersion != null)
            {
                _settings.SkippedUpdate = _latestVersion.ToString();
            }
            Visibility = Visibility.Collapsed;
        }

        public static async Task<Version?> CheckForUpdateAsync()
        {
            var rawAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var assemblyVersion = rawAssemblyVersion != null
                ? new Version(
                    rawAssemblyVersion.Major,
                    rawAssemblyVersion.Minor >= 0 ? rawAssemblyVersion.Minor : 0,
                    rawAssemblyVersion.Build >= 0 ? rawAssemblyVersion.Build : 0,
                    rawAssemblyVersion.Revision >= 0 ? rawAssemblyVersion.Revision : 0)
                : new Version(0, 0, 0, 0);
            var latestVersion = await GetLatestStableReleaseVersion();

            if (latestVersion == null)
                return null;
            if (assemblyVersion == null || assemblyVersion.CompareTo(latestVersion) >= 0)
                return null;

            return latestVersion;
        }

        private sealed class Release
        {
            [JsonPropertyName("tag_name")]
            public string TagName { get; set; } = string.Empty;
        }
    }
}
