using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using EverythingToolbar.App.Helpers;
using NLog;

namespace EverythingToolbar.Services
{
    public static class UpdateService
    {
        private static readonly ILogger Logger = ToolbarLogger.GetLogger(nameof(UpdateService));
        private static readonly HttpClient HttpClient = new();
        public const string LatestReleaseApiUrl =
            "https://api.github.com/repos/Crucialmer/EverythingTB/releases/latest";
        public const string LatestReleaseUrl =
            "https://github.com/Crucialmer/EverythingTB/releases/latest";

        static UpdateService()
        {
            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd("EverythingToolbar");
        }

        public static async Task<ReleaseInfo?> GetLatestReleaseInfoAsync()
        {
            try
            {
                var response = await HttpClient.GetAsync(LatestReleaseApiUrl);
                if (!response.IsSuccessStatusCode)
                    return null;

                await using var jsonStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ReleaseInfo>(jsonStream);
            }
            catch (Exception ex)
            {
                Logger.Info(ex, "Failed to get latest release info.");
                return null;
            }
        }

        public static async Task<Version?> CheckForUpdateAsync()
        {
            var rawAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var currentVersion = rawAssemblyVersion != null
                ? new Version(
                    rawAssemblyVersion.Major,
                    rawAssemblyVersion.Minor >= 0 ? rawAssemblyVersion.Minor : 0,
                    rawAssemblyVersion.Build >= 0 ? rawAssemblyVersion.Build : 0,
                    rawAssemblyVersion.Revision >= 0 ? rawAssemblyVersion.Revision : 0)
                : new Version(0, 0, 0, 0);

            var release = await GetLatestReleaseInfoAsync();
            if (release?.TagName == null)
                return null;

            var versionString = release.TagName.TrimStart('v', 'V');
            if (!Version.TryParse(versionString, out var latestVersion))
                return null;

            var normalizedLatest = new Version(
                latestVersion.Major,
                latestVersion.Minor >= 0 ? latestVersion.Minor : 0,
                latestVersion.Build >= 0 ? latestVersion.Build : 0,
                latestVersion.Revision >= 0 ? latestVersion.Revision : 0);

            if (currentVersion.CompareTo(normalizedLatest) >= 0)
                return null;

            return normalizedLatest;
        }

        public static async Task<bool> DownloadAndInstallUpdateAsync(
            IProgress<double>? progress = null,
            Action<string>? statusCallback = null)
        {
            try
            {
                statusCallback?.Invoke("正在获取最新版本信息...");
                var release = await GetLatestReleaseInfoAsync();
                if (release == null || string.IsNullOrEmpty(release.TagName))
                {
                    statusCallback?.Invoke("获取更新信息失败");
                    return false;
                }

                var asset = release.Assets.FirstOrDefault(a =>
                    a.Name.Equals("EverythingToolbar.zip", StringComparison.OrdinalIgnoreCase))
                    ?? release.Assets.FirstOrDefault(a => a.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));

                if (asset == null || string.IsNullOrEmpty(asset.BrowserDownloadUrl))
                {
                    statusCallback?.Invoke("未找到可用更新压缩包");
                    return false;
                }

                string tempDir = Path.Combine(Path.GetTempPath(), "EverythingToolbarUpdate");
                if (Directory.Exists(tempDir))
                {
                    try { Directory.Delete(tempDir, recursive: true); } catch { }
                }
                Directory.CreateDirectory(tempDir);

                string zipFilePath = Path.Combine(tempDir, "EverythingToolbar.zip");
                statusCallback?.Invoke("正在连接下载服务器...");

                using (var downloadResponse = await HttpClient.GetAsync(asset.BrowserDownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    downloadResponse.EnsureSuccessStatusCode();
                    long? totalBytes = downloadResponse.Content.Headers.ContentLength ?? (asset.Size > 0 ? asset.Size : null);
                    await using var contentStream = await downloadResponse.Content.ReadAsStreamAsync();
                    await using var fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true);

                    var buffer = new byte[81920];
                    long totalRead = 0;
                    int bytesRead;

                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        totalRead += bytesRead;
                        if (totalBytes.HasValue && totalBytes.Value > 0)
                        {
                            double pct = (double)totalRead / totalBytes.Value * 100.0;
                            progress?.Report(pct);
                            statusCallback?.Invoke($"正在下载更新包 ({pct:0}%)...");
                        }
                        else
                        {
                            double mb = totalRead / (1024.0 * 1024.0);
                            statusCallback?.Invoke($"正在下载更新包 ({mb:0.1} MB)...");
                        }
                    }
                }

                statusCallback?.Invoke("正在解压更新文件...");
                string extractDir = Path.Combine(tempDir, "extracted");
                Directory.CreateDirectory(extractDir);
                ZipFile.ExtractToDirectory(zipFilePath, extractDir, overwriteFiles: true);

                // Locate the directory containing EverythingToolbar.Launcher.exe
                string sourceDir = extractDir;
                if (!File.Exists(Path.Combine(sourceDir, "EverythingTB.exe")) && !File.Exists(Path.Combine(sourceDir, "EverythingToolbar.Launcher.exe")))
                {
                    var match = Directory.GetFiles(extractDir, "EverythingTB.exe", SearchOption.AllDirectories).FirstOrDefault() ?? Directory.GetFiles(extractDir, "EverythingToolbar.Launcher.exe", SearchOption.AllDirectories).FirstOrDefault();
                    if (match != null)
                        sourceDir = Path.GetDirectoryName(match)!;
                }

                string targetDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
                string batchScriptPath = Path.Combine(tempDir, "apply_update.cmd");

                string batchContent = $@"@echo off
chcp 65001 >nul
echo 正在安装 EverythingTB 更新并重启...
timeout /t 1 /nobreak >nul
taskkill /F /IM EverythingToolbar.Launcher.exe >nul 2>&1
taskkill /F /IM EverythingToolbar.exe >nul 2>&1
taskkill /F /IM EverythingTB.exe >nul 2>&1
timeout /t 1 /nobreak >nul

robocopy ""{sourceDir}"" ""{targetDir}"" /E /XD ""Config"" /NJH /NJS /NDL /NC /NS >nul
if errorlevel 8 (
    xcopy /Y /E /I /Q ""{sourceDir}\*"" ""{targetDir}\"" >nul
)

if exist ""{targetDir}\EverythingTB.exe"" (
    start """" /d ""{targetDir}"" ""{targetDir}\EverythingTB.exe""
) else if exist ""{targetDir}\EverythingToolbar.Launcher.exe"" (
    start """" /d ""{targetDir}"" ""{targetDir}\EverythingToolbar.Launcher.exe""
) else (
    start """" /d ""{targetDir}"" ""{targetDir}\EverythingToolbar.exe""
)
rd /S /Q ""{sourceDir}"" >nul 2>&1
del ""{zipFilePath}"" >nul 2>&1
(goto) 2>nul & del ""%~f0""
";

                await File.WriteAllTextAsync(batchScriptPath, batchContent, System.Text.Encoding.UTF8);

                statusCallback?.Invoke("下载完成，正在重启更新...");
                await Task.Delay(800);

                var startInfo = new ProcessStartInfo
                {
                    FileName = batchScriptPath,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };

                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                }

                Application.Current?.Dispatcher.Invoke(() =>
                {
                    Application.Current.Shutdown();
                });

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to download and install update.");
                statusCallback?.Invoke($"更新失败: {ex.Message}");
                return false;
            }
        }

        public sealed class ReleaseInfo
        {
            [JsonPropertyName("tag_name")]
            public string TagName { get; set; } = string.Empty;

            [JsonPropertyName("assets")]
            public List<ReleaseAsset> Assets { get; set; } = [];
        }

        public sealed class ReleaseAsset
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("browser_download_url")]
            public string BrowserDownloadUrl { get; set; } = string.Empty;

            [JsonPropertyName("size")]
            public long Size { get; set; }
        }
    }
}
