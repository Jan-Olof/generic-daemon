using functional.common.errors;
using functional.common.valueObjects.validate;
using LanguageExt;
using System;
using static functional.common.valueObjects.validate.V;
using static LanguageExt.Prelude;

namespace functional.common.valueObjects
{
    public readonly struct Timestamp
    {
        private Timestamp(DateTime value) =>
            Value = value;

        public DateTime Value { get; }

        public static Validate<Timestamp> Create(Func<DateTime> now, Origin origin) =>
            IsValid(now.Invoke(), origin);

        public static Validate<Timestamp> Create(DateTime now, Origin origin) =>
            IsValid(now, origin);

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

        private static bool IsValid(DateTime value) =>
            value > new DateTime(2000, 1, 1) && value < new DateTime(2100, 1, 1);

        private static Validate<Timestamp> IsValid(DateTime value, Origin origin) =>
            IsValid(value)
                ? Valid(new Timestamp(value))
                : Invalid(ErrorFactory.TimestampInvalid(value.ToString("s"), origin));
    }
}