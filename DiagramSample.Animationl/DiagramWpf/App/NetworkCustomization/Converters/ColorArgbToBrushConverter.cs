using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WpfProject.App.NetworkCustomization;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class ColorArgbToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? 
                new SolidColorBrush(Colors.Transparent) :
                new SolidColorBrush(ColorHelper.GetColorFromArgb(int.Parse(value.ToString())));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}