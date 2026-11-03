using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EverythingToolbar.Converters
{
    public class ResultFontSizeConverter : MarkupExtension, IValueConverter
    {
        public static readonly ResultFontSizeConverter Instance = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double pt = 11.0;
            if (value is double d && d > 0)
                pt = d;
            else if (value is int i && i > 0)
                pt = i;
            else if (value is string s && double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsed))
                pt = parsed;

            // Optional offset in points, e.g. "-1.5" or "-2.0" for subtext
            if (parameter is string paramStr && double.TryParse(paramStr, NumberStyles.Float, CultureInfo.InvariantCulture, out var offset))
            {
                pt = Math.Max(pt + offset, 8.0);
            }

            // Convert points to WPF DIP (1 pt = 96.0 / 72.0 DIP = 1.3333 DIP)
            return Math.Round(pt * (96.0 / 72.0), 2);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException("This converter cannot be used in two-way binding.");
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
