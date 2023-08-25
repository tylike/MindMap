using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfProject.App.NetworkCustomization
{
    public static class ColorHelper
    {
        public static Color GetColorFromArgb(int argb)
        {
            var bytes = BitConverter.GetBytes(argb);
            return Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
        }

        public static int GetArgbFromColor(Color color)
        {
            return BitConverter.ToInt32(new[] { color.B, color.G, color.R, color.A }, 0);
        }
    }
}
