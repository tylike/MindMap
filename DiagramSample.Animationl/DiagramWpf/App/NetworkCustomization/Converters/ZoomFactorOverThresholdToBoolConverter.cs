using System;
using System.Globalization;
using System.Windows.Data;


namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class ZoomFactorOverThresholdToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }

            var zoom = double.Parse(value.ToString());

            return zoom > GeneralSettings.ZoomThreshold;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}