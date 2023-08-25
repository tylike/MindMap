using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class BoolToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isBold = (bool)value;
            return isBold ? FontWeights.Bold : FontWeights.Regular;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
