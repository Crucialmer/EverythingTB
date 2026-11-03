using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace EverythingToolbar.Converters
{
    public class FontFamilyConverter : MarkupExtension, IValueConverter
    {
        public static readonly FontFamily DefaultFontFamily =
            new("Segoe UI Variable Text, SF Pro Text, Segoe UI, HarmonyOS Sans, Microsoft YaHei UI, sans-serif");

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string fontName && !string.IsNullOrWhiteSpace(fontName) && !fontName.Equals("Default", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return new FontFamily($"{fontName}, Segoe UI Variable Text, SF Pro Text, Segoe UI, HarmonyOS Sans, Microsoft YaHei UI, sans-serif");
                }
                catch
                {
                    // Fallback to default
                }
            }

            return DefaultFontFamily;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is FontFamily ff)
                return ff.Source;

            return "Default";
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
