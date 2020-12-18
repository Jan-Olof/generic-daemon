using functional.common.errors;
using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace functional.common.valueObjects
{
    /// <summary>
    /// A string that contains something.
    /// </summary>
    public struct Text
    {
        private Text(string value) => Value = value;

        private string Value { get; }

        public static implicit operator string(Text c) =>
            c.Value;

        public static bool operator !=(Text left, Text right) =>
            left.Value != right.Value;

        public static bool operator ==(Text left, Text right) =>
            left.Value.Equals(right.Value);

        public override bool Equals(object? obj) =>
            obj is Text ft && this == ft;

        public override int GetHashCode() =>
            Value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() =>
            Value;

        public static Option<Text> Create(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? None
                : Some(new Text(name));

        public static validation.Validation<Text> CreateAndValidate(string name, Origin origin)
        {
            throw new NotImplementedException();
            // TODO: Return here.
            //return string.IsNullOrWhiteSpace(name)
            //    ? Invalid(ErrorFactory.Missing($"Name: {name}", nameof(Text), origin))
            //    : Valid(new Text(name));
        }
    }
}