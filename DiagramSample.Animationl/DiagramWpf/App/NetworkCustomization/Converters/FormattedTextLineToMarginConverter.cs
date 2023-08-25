using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using BusinessLogic;


namespace ProjectB.Views.WPF.DataFlow_2_0.Views.Converters
{
    public class FormattedTextLineToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var formattedLine = value as FormattedTextLine;

            if (formattedLine != null)
            {
                return new Thickness(formattedLine.Indent * 11, formattedLine.PaddingTop, 1, 1);
            }

            return new Thickness(0, 0, 1, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
