using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfProject.App.NetworkCustomization.Converters
{
    class UniformThicknessToParticularThicknessConverter:IValueConverter
    {  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value;
            }

            var uniformThickness = (Thickness)value;
            var uniformValue = uniformThickness.Left;

            var parameters = parameter.ToString().Split(';');

            if (parameters.Length != 4)
            {
                return value;
            }

            return new Thickness(uniformValue * int.Parse(parameters[0]), uniformValue * int.Parse(parameters[1]),
                uniformValue * int.Parse(parameters[2]), uniformValue * int.Parse(parameters[3]));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
