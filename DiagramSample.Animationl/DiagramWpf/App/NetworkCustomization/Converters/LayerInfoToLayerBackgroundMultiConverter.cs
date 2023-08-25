using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class LayerInfoToLayerBackgroundMultiConverter : IMultiValueConverter
    {
        private readonly ColorArgbToBrushConverter _colorArgbToBrushConverter;

        public LayerInfoToLayerBackgroundMultiConverter()
        {
            _colorArgbToBrushConverter = new ColorArgbToBrushConverter();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
            {
                return new SolidColorBrush(Colors.Transparent);
            }

            var showLayers = (bool)values[0];

            if (!showLayers)
            {
                return new SolidColorBrush(Colors.Transparent);
            }

            var argb = (int)values[1];

            return _colorArgbToBrushConverter.Convert(argb, null, null, null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}