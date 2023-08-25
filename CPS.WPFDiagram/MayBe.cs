using System;
using System.Diagnostics;

namespace CPS.WPFDiagram
{
    [DebuggerStepThrough]
    public static class MayBe
    {
        public static TR With<TI, TR>(this TI input, Func<TI, TR> evaluator) where TI : class where TR : class
        {
            if (input == null)
            {
                return null;
            }

            return evaluator(input);
        }

        public static TR WithString<TR>(this string input, Func<string, TR> evaluator) where TR : class
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return evaluator(input);
        }

        public static TR Return<TI, TR>(this TI? input, Func<TI?, TR> evaluator, Func<TR> fallback) where TI : struct
        {
            if (!input.HasValue)
            {
                if (fallback == null)
                {
                    return default(TR);
                }

                return fallback();
            }

            return evaluator(input.Value);
        }

        public static TR Return<TI, TR>(this TI input, Func<TI, TR> evaluator, Func<TR> fallback) where TI : class
        {
            if (input == null)
            {
                if (fallback == null)
                {
                    return default(TR);
                }

                return fallback();
            }

            return evaluator(input);
        }

        public static bool ReturnSuccess<TI>(this TI input) where TI : class
        {
            return input != null;
        }

        public static TI If<TI>(this TI input, Func<TI, bool> evaluator) where TI : class
        {
            if (input == null)
            {
                return null;
            }

            if (!evaluator(input))
            {
                return null;
            }

            return input;
        }

        public static TI IfNot<TI>(this TI input, Func<TI, bool> evaluator) where TI : class
        {
            if (input == null)
            {
                return null;
            }

            if (!evaluator(input))
            {
                return input;
            }

            return null;
        }

        public static TI Do<TI>(this TI input, Action<TI> action) where TI : class
        {
            if (input == null)
            {
                return null;
            }

            action(input);
            return input;
        }
    }
}
