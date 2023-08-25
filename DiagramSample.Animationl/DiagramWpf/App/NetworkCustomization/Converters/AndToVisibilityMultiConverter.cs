using System;
using System.Globalization;
using System.Windows.Data;

using WpfProject.App.NetworkCustomization.Converters;

namespace ProjectB.Views.WPF.Converters
{
    public class AndToVisibilityMultiConverter : IMultiValueConverter
    {
        readonly AndMultiConverter _andMultiConverter = new AndMultiConverter();
        readonly BoolToVisibilityConverter _boolToVisibilityConverter = new BoolToVisibilityConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var andResult = _andMultiConverter.Convert(values, targetType, parameter, culture);
            return _boolToVisibilityConverter.Convert(andResult, targetType, parameter, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
