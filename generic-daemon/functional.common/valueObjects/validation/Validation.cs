using functional.common.errors;
using functional.common.helpers;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace functional.common.valueObjects.validation
{
    public struct Validation<T>
    {
        internal IEnumerable<Error> Errors { get; }
        internal T Value { get; }

        public bool IsValid { get; }

        /// <summary>
        /// The Return function for Validation.
        /// </summary>
        public static Func<T, Validation<T>> Return = t => V.Valid(t);

        public static Validation<T> Fail(IEnumerable<Error> errors) =>
            new Validation<T>(errors);

        public static Validation<T> Fail(params Error[] errors) =>
            new Validation<T>(errors.AsEnumerable());

        private Validation(IEnumerable<Error> errors)
        {
            IsValid = false;
            Errors = errors;
            Value = default(T);
        }

        internal Validation(T right)
        {
            IsValid = true;
            Value = right;
            Errors = Enumerable.Empty<Error>();
        }

        public static implicit operator Validation<T>(Error error) =>
            new Validation<T>(new[] { error });

        public static implicit operator Validation<T>(Validation.Invalid left) =>
            new Validation<T>(left.Errors);

        public static implicit operator Validation<T>(T right) => V.Valid(right);

        public TR Match<TR>(Func<IEnumerable<Error>, TR> Invalid, Func<T, TR> Valid) =>
            IsValid
                ? Valid(this.Value)
                : Invalid(this.Errors);

        public Unit Match(Action<IEnumerable<Error>> Invalid, Action<T> Valid) =>
            Match(Invalid.ToFunc(), Valid.ToFunc());

        public IEnumerator<T> AsEnumerable()
        {
            if (IsValid) yield return Value;
        }

        public override string ToString() =>
            IsValid
                ? $"Valid({Value})"
                : $"Invalid([{string.Join(", ", Errors)}])";

        public override bool Equals(object obj) =>
            ToString() == obj.ToString(); // hack
    }
}