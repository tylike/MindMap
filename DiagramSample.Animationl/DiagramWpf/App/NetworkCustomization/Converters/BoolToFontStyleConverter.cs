using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class BoolToFontStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isItalic = (bool)value;
            return isItalic ? FontStyles.Italic : FontStyles.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
