﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectB.Views.WPF.Converters
{
    public class NotBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vis = (Visibility)value;
            return vis == Visibility.Visible;
        }
    }
}