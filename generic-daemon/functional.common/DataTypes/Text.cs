using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using LanguageExt;
using static Functional.F;
using static LanguageExt.Prelude;

namespace Functional.Common.DataTypes
{
    /// <summary>
    /// A string that contains something.
    /// </summary>
    public readonly struct Text
    {
        private Text(string value) =>
            Value = value;

        private string Value { get; }

        /// <summary>
        /// Create Text or None.
        /// </summary>
        public static Option<Text> Create(string text) =>
            string.IsNullOrWhiteSpace(text)
                ? None
                : Some(new Text(text));

        /// <summary>
        /// Create and validate Text.
        /// </summary>
        public static Validate<Text> Create(string text, Origin origin) =>
            string.IsNullOrWhiteSpace(text)
                ? Invalid(text.CreateTextInvalidError(origin))
                : Valid(new Text(text));

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
    }
}