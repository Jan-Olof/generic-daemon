using functional.common.errors;
using System.Collections.Generic;

namespace functional.common.valueObjects.validation
{
    /// <summary>
    /// Create Validation.
    /// </summary>
    public static class V
    {
        /// <summary>
        /// Create a Validation in the Valid state.
        /// </summary>
        public static Validation<T> Valid<T>(T value) =>
            new Validation<T>(value);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validation.Invalid Invalid(params Error[] errors) =>
            new Validation.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validation<T> Invalid<T>(params Error[] errors) =>
            new Validation.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validation.Invalid Invalid(IEnumerable<Error> errors) =>
            new Validation.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validation<T> Invalid<T>(IEnumerable<Error> errors) =>
            new Validation.Invalid(errors);
    }
}