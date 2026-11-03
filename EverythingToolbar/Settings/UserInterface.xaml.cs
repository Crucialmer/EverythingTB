using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using EverythingToolbar.Controls;
using EverythingToolbar.Core.Data;
using EverythingToolbar.Helpers;
using EverythingToolbar.Icons;
using EverythingToolbar.Properties;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using MessageBoxResult = Wpf.Ui.Controls.MessageBoxResult;

namespace EverythingToolbar.Settings
{
    public partial class UserInterface
    {
        public UserInterface()
        {
            InitializeComponent();
            var viewModel = new UserInterfaceViewModel();
            DataContext = viewModel;
            ColorPickerPopup.DataContext = viewModel;
        }

        private void OnColorPickerButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is UIElement target)
            {
                ColorPickerPopup.PlacementTarget = target;
                ColorPickerPopup.IsOpen = !ColorPickerPopup.IsOpen;
            }
        }
    }

    public partial class UserInterfaceViewModel : ObservableObject
    {
        public ISettings Settings { get; } = Ioc.Default.GetRequiredService<ISettings>();

        public List<KeyValuePair<string, double>> ResultFontSizes { get; } =
        [
            new("9 pt", 9.0),
            new("10 pt (\u9ED8\u8BA4)", 10.0),
            new("11 pt", 11.0),
            new("12 pt", 12.0),
            new("13 pt", 13.0),
            new("14 pt", 14.0),
            new("15 pt", 15.0),
            new("16 pt", 16.0),
        ];

        public List<KeyValuePair<string, double>> SearchBoxFontSizes { get; } =
        [
            new("9 pt", 9.0),
            new("10 pt (\u9ED8\u8BA4)", 10.0),
            new("11 pt", 11.0),
            new("12 pt", 12.0),
            new("13 pt", 13.0),
            new("14 pt", 14.0),
            new("15 pt", 15.0),
            new("16 pt", 16.0),
        ];

        public List<KeyValuePair<string, string>> FontWeightsList { get; } =
        [
            new("\u5E38\u89C4 (Normal)", "Normal"),
            new("\u4E2D\u7B49 (Medium)", "Medium"),
            new("\u534A\u7C97 (SemiBold)", "SemiBold"),
            new("\u52A0\u7C97 (Bold)", "Bold"),
        ];

        public List<KeyValuePair<string, string>> AvailableFontFamilies { get; } = GetAvailableFontFamilies();

        private static string GetFontDisplayName(FontFamily font)
        {
            try
            {
                var zhLang = System.Windows.Markup.XmlLanguage.GetLanguage("zh-cn");
                if (font.FamilyNames.TryGetValue(zhLang, out var zhName) && !string.IsNullOrWhiteSpace(zhName))
                {
                    if (!string.Equals(zhName, font.Source, StringComparison.OrdinalIgnoreCase))
                    {
                        return $"{zhName} ({font.Source})";
                    }
                    return zhName;
                }

                var currentLang = System.Windows.Markup.XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag);
                if (font.FamilyNames.TryGetValue(currentLang, out var currentName) && !string.IsNullOrWhiteSpace(currentName))
                {
                    if (!string.Equals(currentLang.IetfLanguageTag, zhLang.IetfLanguageTag, StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(currentName, font.Source, StringComparison.OrdinalIgnoreCase))
                    {
                        return $"{currentName} ({font.Source})";
                    }
                    return currentName;
                }

                var enLang = System.Windows.Markup.XmlLanguage.GetLanguage("en-us");
                if (font.FamilyNames.TryGetValue(enLang, out var enName) && !string.IsNullOrWhiteSpace(enName))
                {
                    return enName;
                }
            }
            catch
            {
                // Fallback
            }

            return font.Source;
        }

        private static List<KeyValuePair<string, string>> GetAvailableFontFamilies()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new("\u7CFB\u7EDF\u9ED8\u8BA4 / macOS 26 (\u52A8\u6001 Segoe UI & \u5FAE\u8F6F\u96C5\u9ED1)", "Default"),
            };

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Default"
            };

            try
            {
                var installedFonts = System.Windows.Media.Fonts.SystemFontFamilies
                    .Where(f => !string.IsNullOrWhiteSpace(f.Source))
                    .Select(f => new
                    {
                        Family = f,
                        Source = f.Source,
                        DisplayName = GetFontDisplayName(f)
                    })
                    .GroupBy(x => x.Source, StringComparer.OrdinalIgnoreCase)
                    .Select(g => g.First())
                    .OrderBy(x => x.DisplayName, StringComparer.CurrentCultureIgnoreCase)
                    .ToList();

                foreach (var font in installedFonts)
                {
                    if (seen.Add(font.Source))
                    {
                        list.Add(new KeyValuePair<string, string>(font.DisplayName, font.Source));
                    }
                }
            }
            catch
            {
                // Fallback
            }

            return list;
        }

                public List<KeyValuePair<string, string>> ItemTemplates { get; } =
        [
            new(Resources.ItemTemplateCompact, "Compact"),
            new(Resources.ItemTemplateCompactDetailed, "CompactDetailed"),
            new(Resources.ItemTemplateNormal, "Normal"),
            new(Resources.ItemTemplateNormalDetailed, "NormalDetailed"),
        ];
        public List<KeyValuePair<string, string>> Languages { get; } = CultureHelper.GetAvailableLanguages();
        public List<KeyValuePair<string, string>> SearchWindowBackgroundOptions { get; } =
        [
            new(Resources.SearchWindowBackgroundAutomatic, "Automatic"),
            new(Resources.SearchWindowBackgroundCustom, "Custom"),
        ];

        public string SearchWindowBackground
        {
            get => Settings.SearchWindowBackground;
            set
            {
                if (Settings.SearchWindowBackground != value)
                {
                    Settings.SearchWindowBackground = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCustomColorSelected));
                }
            }
        }

        public bool IsCustomColorSelected => Settings.SearchWindowBackground == "Custom";

        public int CustomColorAlpha
        {
            get => Settings.SearchWindowBackgroundAlpha;
            set
            {
                int clamped = Math.Clamp(value, 0, 255);
                if (Settings.SearchWindowBackgroundAlpha != clamped)
                {
                    Settings.SearchWindowBackgroundAlpha = clamped;
                }
            }
        }

        public int CustomColorBrightness
        {
            get => Settings.SearchWindowBackgroundBrightness;
            set
            {
                int clamped = Math.Clamp(value, 0, 100);
                if (Settings.SearchWindowBackgroundBrightness != clamped)
                {
                    Settings.SearchWindowBackgroundBrightness = clamped;
                }
            }
        }

        private SolidColorBrush _customColorBrush = ColorHelper.ToFrozenBrush(ColorHelper.DefaultSearchWindowColor);
        public SolidColorBrush CustomColorBrush
        {
            get => _customColorBrush;
            private set => SetProperty(ref _customColorBrush, value);
        }

        private string _customColorHex = ColorHelper.ToHex(ColorHelper.DefaultSearchWindowColor);
        public string CustomColorHex
        {
            get => _customColorHex;
            private set => SetProperty(ref _customColorHex, value);
        }

        public string SelectedLanguage
        {
            get => Settings.UILanguage;
            set
            {
                if (Settings.UILanguage != value)
                {
                    Settings.UILanguage = value;
                    OnPropertyChanged();
                    OnUILanguageChanged();
                }
            }
        }

        public SearchResult SampleSearchResult { get; }

        public bool IsLauncher => Application.Current != null;

        public UserInterfaceViewModel()
        {
            UpdateBrushAndHex();

            var themeService = Ioc.Default.GetService<ThemeService>();
            if (themeService != null)
            {
                themeService.ThemeChanged += (s, e) => UpdateBrushAndHex();
            }

            Settings.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(ISettings.SearchWindowBackground):
                        OnPropertyChanged(nameof(SearchWindowBackground));
                        OnPropertyChanged(nameof(IsCustomColorSelected));
                        break;
                    case nameof(ISettings.SearchWindowBackgroundAlpha):
                        OnPropertyChanged(nameof(CustomColorAlpha));
                        UpdateBrushAndHex();
                        break;
                    case nameof(ISettings.SearchWindowBackgroundBrightness):
                        OnPropertyChanged(nameof(CustomColorBrightness));
                        UpdateBrushAndHex();
                        break;
                    case nameof(ISettings.ThemeOverride):
                        UpdateBrushAndHex();
                        break;
                }
            };

            BitmapImage imageSource = new(
                new Uri("pack://application:,,,/EverythingToolbar;component/Images/AppIcon.ico")
            );
            SampleSearchResult = new SearchResult(
                HighlightedPath: @"C:\Program Files\EverythingTB\Everything*TB*.exe",
                HighlightedFileName: "Everything*TB*",
                FullPathAndFileName: @"C:\Program Files\EverythingTB\EverythingTB.exe",
                IsFile: true,
                FileSize: 12345678,
                DateModified: new FILETIME
                {
                    dwHighDateTime = DateTimeToFileTime(DateTime.Now).dwHighDateTime,
                    dwLowDateTime = DateTimeToFileTime(DateTime.Now).dwLowDateTime,
                }
            );

            ResultImageCache.Get(SampleSearchResult).SetFixedIcon(imageSource);
        }

        private void UpdateBrushAndHex()
        {
            var themeService = Ioc.Default.GetService<ThemeService>();
            var isLight = themeService?.IsLightTheme() ?? false;
            var color = ColorHelper.GetSearchWindowColor(
                Settings.SearchWindowBackgroundAlpha,
                Settings.SearchWindowBackgroundBrightness,
                isLight
            );
            CustomColorBrush = ColorHelper.ToFrozenBrush(color);
            CustomColorHex = ColorHelper.ToHex(color);
        }

        private static FILETIME DateTimeToFileTime(DateTime dateTime)
        {
            long fileTime = dateTime.ToFileTimeUtc();
            return new FILETIME
            {
                dwLowDateTime = (int)(fileTime & 0xFFFFFFFF),
                dwHighDateTime = (int)(fileTime >> 32),
            };
        }

        private async void OnUILanguageChanged()
        {
            var result = await FluentMessageBox
                .CreateYesNo(Resources.MessageBoxRestartMessage, Resources.MessageBoxRestartTitle)
                .ShowDialogAsync();

            if (result != MessageBoxResult.Primary)
                return;

            string? executablePath = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;

            if (IsLauncher && executablePath != null)
            {
                // Start a new instance with a delay to allow the current one to exit and release the Mutex
                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c timeout /t 1 /nobreak && start \"\" \"{executablePath}\"",
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                    }
                );
            }

            // Always restart explorer to provide consistent visual feedback/refresh
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }

            if (IsLauncher)
            {
                Application.Current.Shutdown();
            }
        }
    }
}