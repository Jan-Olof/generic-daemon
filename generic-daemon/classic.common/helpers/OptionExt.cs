using classic.common.time;
using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace classic.common.helpers
{
    /// <summary>
    /// Extensions to LaYumba.Functional.Option.
    /// </summary>
    public static class OptionExt
    {
        /// <summary>
        /// If an object equals an object, then return the object. Otherwise return None.
        /// </summary>
        public static Option<T> EqualOrNone<T>(this T t1, T t2) where T : IEquatable<T> =>
            t1.Equals(t2) ? Some(t1) : None;

        /// <summary>
        /// Get the object, or throw InvalidOperationException. (So, this can only be used when we know that the object is Some.)
        /// </summary>
        public static T GetObject<T>(this Option<T> option) =>
            option.Match(() => throw new InvalidOperationException("The object is None."), t => t);

        /// <summary>
        /// Find out if the Option is Some or None.
        /// </summary>
        public static bool IsNone<T>(this Option<T> option) =>
            option.Match(() => true, t => false);

        /// <summary>
        /// Find out if the Option is Some or None.
        /// </summary>
        public static bool IsSome<T>(this Option<T> option) =>
            option.Match(() => false, t => true);

        /// <summary>
        /// Convert option Timestamp to a DateTime.
        /// </summary>
        public static DateTime OptionToDateTime(this Option<Timestamp> timestamp) =>
            timestamp.Match(DateTimes.Default, t => timestamp.GetObject());

        public static Option<T> ToNone<T>() => None;

        /// <summary>
        /// Converts an Option into a Validation.
        /// </summary>
        public static Validation<T> ToValidation<T>(this Option<T> option, Error error) =>
            option.Match(() => Invalid(error), Valid);
    }
}