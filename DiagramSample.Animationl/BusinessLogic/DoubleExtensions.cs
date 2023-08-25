using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class DoubleExtensions
    {
        public static bool QuasiEqualTo(this double value1, double value2)
        {
            return Math.Abs(value1 - value2) < 0.0000001;
        }
    }
}
