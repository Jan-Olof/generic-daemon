using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Functional.Common.Helpers
{
    public static class DateTimes
    {
        /// <summary>
        /// Create the default DateTime value (1900-01-01).
        /// </summary>
        public static DateTime Default() =>
            new DateTime(1900, 1, 1);

        public static DateTime DefaultMinus() =>
            new DateTime(1800, 1, 1);

        public static bool IsDefault(this DateTime d) =>
            d <= Default();

        public static bool IsNotDefault(this DateTime d) =>
            d > Default();

        /// <summary>
        /// Suspends the current thread for the specified number of milliseconds.
        /// </summary>
        public static Unit Wait(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
            return unit;
        }
    }
}