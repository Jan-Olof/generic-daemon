using functional.common.errors;
using functional.common.helpers;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using static functional.common.valueObjects.validate.V;

#pragma warning disable 8618
#pragma warning disable 8601

namespace functional.common.valueObjects.validate
{
    public readonly struct Validate<T>
    {
        internal IEnumerable<Error> Errors { get; }

        internal T Value { get; }

        public bool IsValid { get; }

        /// <summary>
        /// The Return function for Validation.
        /// </summary>
        public static Func<T, Validate<T>> Return = t => Valid(t);

        public static Validate<T> Fail(IEnumerable<Error> errors) =>
            new Validate<T>(errors);

        public static Validate<T> Fail(params Error[] errors) =>
            new Validate<T>(errors.AsEnumerable());

        private Validate(IEnumerable<Error> errors)
        {
            IsValid = false;
            Errors = errors;
            Value = default(T);
        }

        internal Validate(T right)
        {
            IsValid = true;
            Value = right;
            Errors = Enumerable.Empty<Error>();
        }

        public static implicit operator Validate<T>(Error error) =>
            new Validate<T>(new[] { error });

        public static implicit operator Validate<T>(Validate.Invalid left) =>
            new Validate<T>(left.Errors);

        public static implicit operator Validate<T>(T right) => Valid(right);

        public TR Match<TR>(Func<IEnumerable<Error>, TR> invalid, Func<T, TR> valid) =>
            IsValid
                ? valid(Value)
                : invalid(Errors);

        public Unit Match(Action<IEnumerable<Error>> invalid, Action<T> valid) =>
            Match(invalid.ToFunc(), valid.ToFunc());

        public IEnumerator<T> AsEnumerable()
        {
            if (IsValid) yield return Value;
        }

        public override string ToString() =>
            IsValid
                ? $"Valid({Value})"
                : $"Invalid([{string.Join(", ", Errors)}])";

        public override bool Equals(object? obj) =>
            ToString() == obj?.ToString(); // hack

        public override int GetHashCode() =>
            throw new NotImplementedException();
    }
}