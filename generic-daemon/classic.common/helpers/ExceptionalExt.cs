using LaYumba.Functional;
using System;
using Unit = System.ValueTuple;

namespace classic.common.helpers
{
    /// <summary>
    /// Extensions to LaYumba.Functional.Exceptional.
    /// </summary>
    public static class ExceptionalExt
    {
        /// <summary>
        /// Get exception, or throw InvalidOperationException.
        /// </summary>
        public static Exception GetException<T>(this Exceptional<T> exceptional) =>
            exceptional.Match(e => e, t => throw new InvalidOperationException("The object is an exception."));

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know that the object is valid.)
        /// </summary>
        public static T GetObject<T>(this Exceptional<T> exceptional) =>
            exceptional.Match(e => throw new InvalidOperationException("The object is an exception."), t => t);

        // ReSharper disable once UnusedParameter.Global
        public static Exceptional<T> To<T>(this Exceptional<Unit> u, T t) => t;
    }
}