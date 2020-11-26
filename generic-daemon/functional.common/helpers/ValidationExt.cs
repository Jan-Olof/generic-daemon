using LaYumba.Functional;
using System;
using System.Collections.Generic;

namespace functional.common.helpers
{
    /// <summary>
    /// Extensions to LaYumba.Functional.Validation.
    /// </summary>
    public static class ValidationExt
    {
        /// <summary>
        /// Get all errors.
        /// </summary>
        public static IEnumerable<Error> GetErrors<T>(this Validation<T> validation) =>
            validation.Match(e => e, t => new List<Error>());

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know that the object is valid.)
        /// </summary>
        public static T GetObject<T>(this Validation<T> validation) =>
            validation.Match(
                e => throw new InvalidOperationException("The object is invalid."),
                t => t);
    }
}