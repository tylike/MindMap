using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class BoolToTextWrappingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wrap = (bool)value;
            return wrap ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
    