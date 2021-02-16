using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using LanguageExt;
using System;
using static Functional.F;
using static LanguageExt.Prelude;

namespace Functional.Common.DataTypes
{
    public readonly struct Timestamp
    {
        private Timestamp(DateTime value) =>
            Value = value;

        private DateTime Value { get; }

        /// <summary>
        /// Create and validate Timestamp.
        /// </summary>
        public static Validate<Timestamp> Create(Func<DateTime> now, Origin origin) =>
            IsValid(now.Invoke(), origin);

        /// <summary>
        /// Create and validate Timestamp.
        /// </summary>
        public static Validate<Timestamp> Create(DateTime now, Origin origin) =>
            IsValid(now, origin);

        /// <summary>
        /// Create Timestamp or None.
        /// </summary>
        public static Option<Timestamp> Create(DateTime now) =>
            IsValid(now)
                ? Some(new Timestamp(now))
                : None;

        public static implicit operator DateTime(Timestamp timestamp) =>
            timestamp.Value;

        public static bool operator !=(Timestamp left, Timestamp right) =>
            !(left.Value == right.Value);

        public static bool operator ==(Timestamp left, Timestamp right) =>
            left.Value.Equals(right.Value);

        public override bool Equals(object? obj) =>
            obj is Timestamp ts && this == ts;

        public override int GetHashCode() =>
            Value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() =>
            Value.ToString("s");

        private static bool IsValid(DateTime value) =>
            value > new DateTime(2000, 1, 1) && value < new DateTime(2100, 1, 1);

        private static Validate<Timestamp> IsValid(DateTime value, Origin origin) =>
            IsValid(value)
                ? Valid(new Timestamp(value))
                : Invalid(value.ToString("s").CreateTimestampInvalidError(origin));
    }
}