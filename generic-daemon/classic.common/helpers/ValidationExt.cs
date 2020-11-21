using LaYumba.Functional;
using System;
using System.Collections.Generic;

namespace classic.common.helpers
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
        /// Get the all error messages.
        /// </summary>
        public static string GetMessages(this IEnumerable<Error> errors) =>
            string.Join(",", errors.Map(e => e.Message));

        /// <summary>
        /// Get the valid object, or throw InvalidOperationException. (So, this can only be used when we know that the object is valid.)
        /// </summary>
        public static T GetObject<T>(this Validation<T> validation) =>
            validation.Match(
                e => throw new InvalidOperationException("The object is invalid."),
                t => t);

        /// <summary>
        /// Verify if a validation is invalid.
        /// </summary>
        public static bool IsInvalid<T>(this Validation<T> validation) =>
            !validation.IsValid;
    }
}