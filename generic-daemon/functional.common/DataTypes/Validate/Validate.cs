using Functional.Common.Errors;
using Functional.Common.Helpers;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using static Functional.F;

#pragma warning disable 8618
#pragma warning disable 8601

namespace Functional.Common.DataTypes.Validate
{
    public readonly struct Validate<T>
    {
        /// <summary>
        /// The Return function for Validation.
        /// </summary>
        public static Func<T, Validate<T>> Return = t => Valid(t);

        internal Validate(T right)
        {
            IsValid = true;
            Value = right;
            Errors = Enumerable.Empty<Error>();
        }

        private Validate(IEnumerable<Error> errors)
        {
            IsValid = false;
            Errors = errors;
            Value = default(T);
        }

        public bool IsValid { get; }

        internal IEnumerable<Error> Errors { get; }

        internal T Value { get; }

        public static Validate<T> Fail(IEnumerable<Error> errors) =>
            new Validate<T>(errors);

        public static Validate<T> Fail(params Error[] errors) =>
            new Validate<T>(errors.AsEnumerable());

        public static implicit operator Validate<T>(Error error) =>
            new Validate<T>(new[] { error });

        public static implicit operator Validate<T>(Validate.Invalid left) =>
            new Validate<T>(left.Errors);

        public static implicit operator Validate<T>(T right) => Valid(right);

        public IEnumerator<T> AsEnumerable()
        {
            if (IsValid) yield return Value;
        }

        public override bool Equals(object? obj) =>
            ToString() == obj?.ToString();

        public override int GetHashCode() =>
            throw new NotImplementedException();

        public TR Match<TR>(Func<IEnumerable<Error>, TR> invalid, Func<T, TR> valid) =>
                                    IsValid
                ? valid(Value)
                : invalid(Errors);

        public Unit Match(Action<IEnumerable<Error>> invalid, Action<T> valid) =>
            Match(invalid.ToFunc(), valid.ToFunc());

        public override string ToString() =>
            IsValid
                ? $"Valid({Value})"
                : $"Invalid([{string.Join(", ", Errors)}])";

        // hack
    }
}