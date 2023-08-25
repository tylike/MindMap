using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfProject.App.NetworkCustomization.Converters
{
    public class AndMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
            {
                return false;
            }

            // https://stackoverflow.com/questions/14226638/handling-a-bool-fallback-value-for-a-binding-within-a-multibinding
            var bools = values.Where(b => b is bool).Cast<bool>().ToList();

            return bools.Count == values.Length && bools.All(x => x);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
