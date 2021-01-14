using Functional.Common.Errors;
using System.Collections.Generic;

namespace Functional.Common.DataTypes.Validate
{
    /// <summary>
    /// Create Validation.
    /// </summary>
    public static partial class V
    {
        /// <summary>
        /// Create a Validation in the Valid state.
        /// </summary>
        public static Validate<T> Valid<T>(T value) =>
            new Validate<T>(value);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validate.Invalid Invalid(params Error[] errors) =>
            new Validate.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validate<T> Invalid<T>(params Error[] errors) =>
            new Validate.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validate.Invalid Invalid(IEnumerable<Error> errors) =>
            new Validate.Invalid(errors);

        /// <summary>
        /// Create a Validation in the Invalid state.
        /// </summary>
        public static Validate<T> Invalid<T>(IEnumerable<Error> errors) =>
            new Validate.Invalid(errors);
    }
}