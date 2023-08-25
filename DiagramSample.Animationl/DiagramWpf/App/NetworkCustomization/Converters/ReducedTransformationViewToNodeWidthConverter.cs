using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using BusinessLogic;


namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class ReducedTransformationViewToNodeWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NetworkTransformationNode)
            {
                return 15;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
