using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using DevExpress.Data.Utils;

namespace ProjectB.Views.WPF.Converters
{
    public class ByteArrayToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is byte[] bytes)
            {
                // https://www.devexpress.com/Support/Center/Question/Details/T749054/diagramimages-are-printed-with-the-same-image-to-a-pdf-document
                return ImageHelper.GetBitmapImageFromByteArray(bytes);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ImageHelper
    {
        public static BitmapImage GetBitmapImageFromByteArray(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(bytes))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }

            image.Freeze();
            return image;
        }
    }
}