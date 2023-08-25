using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectB.Views.WPF.Converters
{
    public class BoolToStringSelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            var parameters = parameter.ToString().Split(';');
            if ((bool)value)
            {
                return parameters[0];
            }
            return parameters[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
