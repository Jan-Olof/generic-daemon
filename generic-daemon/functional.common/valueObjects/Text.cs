using functional.common.errors;
using functional.common.valueObjects.validation;
using LanguageExt;
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

        public static Validation<Text> CreateAndValidate(string name, Origin origin) =>
            string.IsNullOrWhiteSpace(name)
                ? V.Invalid(ErrorFactory.Missing($"Name: {name}", origin))
                : V.Valid(new Text(name));
    }
}