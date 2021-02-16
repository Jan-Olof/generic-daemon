// ReSharper disable CheckNamespace

using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using System.Collections.Generic;

namespace Functional
{
    /// <summary>
    /// Create Validation.
    /// </summary>
    public static partial class F
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