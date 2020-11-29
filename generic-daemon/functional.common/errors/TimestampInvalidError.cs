namespace functional.common.errors
{
    public sealed class TimestampInvalidError : Error
    {
        public TimestampInvalidError(string timestamp, Origin origin)
            : base($"The timestamp {timestamp} is invalid.", origin) { }
    }
}