using classic.common.errors;
using LaYumba.Functional;
using System;
using static LaYumba.Functional.F;

namespace classic.common.time
{
    public struct Timestamp
    {
        private Timestamp(DateTime value) =>
            Value = value;

        public DateTime Value { get; }

        public static Validation<Timestamp> Create(Func<DateTime> now, string origin)
        {
            var value = now.Invoke();

            return IsValid(value)
                ? Valid(new Timestamp(value))
                : Invalid(ErrorFactory.TimestampInvalid(value.ToString("s"), origin));
        }

        public static Validation<Timestamp> Create(DateTime now, string origin) =>
            IsValid(now)
                ? Valid(new Timestamp(now))
                : Invalid(ErrorFactory.TimestampInvalid(now.ToString("s"), origin));

        public static Option<Timestamp> CreateOptional(DateTime now) =>
            IsValid(now)
                ? Some(new Timestamp(now))
                : None;

        public static implicit operator DateTime(Timestamp timestamp) =>
            timestamp.Value;

        public static bool operator !=(Timestamp left, Timestamp right) =>
            !(left == right);

        public static bool operator ==(Timestamp left, Timestamp right) =>
            left.Equals(right);

        public override bool Equals(object? obj) =>
            obj is Timestamp ts && this == ts;

        public override int GetHashCode() =>
            Value.GetHashCode();

        private static bool IsValid(DateTime value) =>
            value > new DateTime(2000, 1, 1) && value < new DateTime(2100, 1, 1);
    }
}