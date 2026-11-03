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

        public ObservableCollection<KeyValuePair<string, string>> AvailableFontWeights { get; } = new();
        public ObservableCollection<KeyValuePair<string, string>> FontWeightsList => AvailableFontWeights;

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
            RefreshAvailableFontWeights();

            var themeService = Ioc.Default.GetService<ThemeService>();
            if (themeService != null)
            {
                themeService.ThemeChanged += (s, e) => UpdateBrushAndHex();
            }

            Settings.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(ISettings.FontFamily):
                        RefreshAvailableFontWeights();
                        break;
                    case nameof(ISettings.SearchWindowBackground):
                        OnPropertyChanged(nameof(SearchWindowBackground));
                        OnPropertyChanged(nameof(IsCustomColorSelected));
                        break;
                    case nameof(ISettings.SearchWindowBackgroundAlpha):
                        OnPropertyChanged(nameof(CustomColorAlpha));
                        UpdateBrushAndHex();
            RefreshAvailableFontWeights();
                        break;
                    case nameof(ISettings.SearchWindowBackgroundBrightness):
                        OnPropertyChanged(nameof(CustomColorBrightness));
                        UpdateBrushAndHex();
            RefreshAvailableFontWeights();
                        break;
                    case nameof(ISettings.ThemeOverride):
                        UpdateBrushAndHex();
            RefreshAvailableFontWeights();
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
        private void RefreshAvailableFontWeights()
        {
            var weights = GetFontWeightsForFamily(Settings.FontFamily);
            AvailableFontWeights.Clear();
            foreach (var w in weights)
            {
                AvailableFontWeights.Add(w);
            }

            if (!AvailableFontWeights.Any(w => string.Equals(w.Value, Settings.ResultFontWeight, StringComparison.OrdinalIgnoreCase)))
            {
                var fallback = AvailableFontWeights.FirstOrDefault(w => string.Equals(w.Value, "Normal", StringComparison.OrdinalIgnoreCase)).Value
                               ?? AvailableFontWeights.FirstOrDefault().Value;
                if (!string.IsNullOrEmpty(fallback))
                    Settings.ResultFontWeight = fallback;
            }

            if (!AvailableFontWeights.Any(w => string.Equals(w.Value, Settings.SearchBoxFontWeight, StringComparison.OrdinalIgnoreCase)))
            {
                var fallback = AvailableFontWeights.FirstOrDefault(w => string.Equals(w.Value, "Normal", StringComparison.OrdinalIgnoreCase)).Value
                               ?? AvailableFontWeights.FirstOrDefault().Value;
                if (!string.IsNullOrEmpty(fallback))
                    Settings.SearchBoxFontWeight = fallback;
            }
        }

        public static List<KeyValuePair<string, string>> GetFontWeightsForFamily(string? fontFamilyName)
        {
            var standardWeights = new (int Weight, string Value, string ZhName, string EnName)[]
            {
                (100, "Thin", "\u6781\u7EC6", "Ultralight / Thin 100"),
                (200, "ExtraLight", "\u7EA4\u7EC6", "Thin / ExtraLight 200"),
                (300, "Light", "\u7EC6\u4F53", "Light 300"),
                (350, "350", "\u6B21\u7EC6", "Semilight 350"),
                (400, "Normal", "\u5E38\u89C4", "Regular / Normal 400"),
                (500, "Medium", "\u4E2D\u9ED1 / \u4E2D\u7B49", "Medium 500"),
                (600, "SemiBold", "\u4E2D\u7C97 / \u534A\u7C97", "SemiBold 600"),
                (700, "Bold", "\u7C97\u4F53", "Bold 700"),
                (800, "ExtraBold", "\u7279\u7C97", "Heavy / ExtraBold 800"),
                (900, "Black", "\u9ED1\u4F53", "Black 900")
            };

            var result = new List<KeyValuePair<string, string>>();

            FontFamily? family = null;
            if (!string.IsNullOrWhiteSpace(fontFamilyName) && !string.Equals(fontFamilyName, "Default", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    family = Fonts.SystemFontFamilies.FirstOrDefault(f => string.Equals(f.Source, fontFamilyName, StringComparison.OrdinalIgnoreCase))
                             ?? new FontFamily(fontFamilyName);
                }
                catch { }
            }

            var probedTypefaces = new Dictionary<int, string>();
            if (family != null)
            {
                try
                {
                    var zhLang = System.Windows.Markup.XmlLanguage.GetLanguage("zh-cn");
                    var enLang = System.Windows.Markup.XmlLanguage.GetLanguage("en-us");

                    foreach (var tf in family.GetTypefaces())
                    {
                        int weight = tf.Weight.ToOpenTypeWeight();
                        string faceName = "";
                        if (tf.FaceNames.TryGetValue(zhLang, out var zh) && !string.IsNullOrWhiteSpace(zh))
                            faceName = zh;
                        else if (tf.FaceNames.TryGetValue(enLang, out var en) && !string.IsNullOrWhiteSpace(en))
                            faceName = en;

                        if (!probedTypefaces.ContainsKey(weight) || tf.Style == FontStyles.Normal)
                        {
                            probedTypefaces[weight] = faceName;
                        }
                    }
                }
                catch { }
            }

            bool isPingFang = !string.IsNullOrEmpty(fontFamilyName) && 
                (fontFamilyName.IndexOf("PingFang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                 fontFamilyName.IndexOf("\u82F9\u65B9", StringComparison.OrdinalIgnoreCase) >= 0);

            // If a specific font has 3 or more detected typefaces and is not PingFang (which has full 100~900 spectrum)
            if (!isPingFang && probedTypefaces.Count >= 3)
            {
                var sortedWeights = probedTypefaces.Keys.OrderBy(w => w).ToList();
                foreach (int w in sortedWeights)
                {
                    string detectedName = probedTypefaces[w];
                    var std = standardWeights.FirstOrDefault(s => Math.Abs(s.Weight - w) < 30);
                    string stdValue = !string.IsNullOrEmpty(std.Value) ? std.Value : w.ToString();
                    string stdZh = std.ZhName ?? "\u5B57\u91CD";
                    string stdEn = std.EnName ?? stdValue;

                    string label;
                    if (!string.IsNullOrWhiteSpace(detectedName) && !string.Equals(detectedName, stdValue, StringComparison.OrdinalIgnoreCase))
                    {
                        label = $"{w} - {detectedName} ({stdEn})";
                    }
                    else
                    {
                        label = $"{w} - {stdZh} ({stdEn})";
                    }

                    result.Add(new KeyValuePair<string, string>(label, stdValue));
                }
                return result;
            }

            // PingFang (鑻规柟), Default, or variable fonts: provide full 100~900 spectrum tailored with detected names
            foreach (var std in standardWeights)
            {
                if (std.Weight == 350 && !probedTypefaces.ContainsKey(350))
                    continue;

                string faceName = "";
                if (probedTypefaces.TryGetValue(std.Weight, out var fn) && !string.IsNullOrWhiteSpace(fn))
                {
                    faceName = fn;
                }

                string label = !string.IsNullOrWhiteSpace(faceName) && !string.Equals(faceName, std.Value, StringComparison.OrdinalIgnoreCase)
                    ? $"{std.Weight} - {faceName} ({std.EnName})"
                    : $"{std.Weight} - {std.ZhName} ({std.EnName})";

                result.Add(new KeyValuePair<string, string>(label, std.Value));
            }

            return result;
        }
    }
}