using System;

namespace functional.common.errors
{
    public sealed class TimestampInvalidError : GenericError
    {
        public TimestampInvalidError(string timestamp, string origin) : base(origin, nameof(TimestampInvalidError)) =>
            Message = $"The timestamp {timestamp} is invalid. {Origin}";

        private TimestampInvalidError(Guid entityId, TimestampInvalidError e) : base(entityId, e.Origin, nameof(TimestampInvalidError)) =>
            Message = e.Message;

        public override string Message { get; }

        /// <inheritdoc />
        public override GenericError Create(Guid entityId) =>
            new TimestampInvalidError(entityId, this);
    }
}