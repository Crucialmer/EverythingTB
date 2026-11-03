using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace EverythingToolbar.Converters
{
    public class SafeFontWeightConverter : MarkupExtension, IValueConverter
    {
        private static readonly System.Windows.FontWeightConverter WpfFontWeightConverter = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is FontWeight fw)
                return fw;

            if (value is string s && !string.IsNullOrWhiteSpace(s))
            {
                if (int.TryParse(s, out int weightNum) && weightNum >= 1 && weightNum <= 1000)
                {
                    return FontWeight.FromOpenTypeWeight(weightNum);
                }

                try
                {
                    if (WpfFontWeightConverter.ConvertFromString(s) is FontWeight converted)
                        return converted;
                }
                catch
                {
                    // Fallback to normal
                }
            }

            return FontWeights.Normal;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is FontWeight fw)
                return fw.ToString();

            return "Normal";
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
