using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{   
    public class WidthEnumToDiagramContentItemWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue)
            {
                return Binding.DoNothing;
            }
            return System.Convert.ToDouble((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}