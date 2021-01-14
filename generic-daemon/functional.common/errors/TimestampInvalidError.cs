namespace Functional.Common.Errors
{
    public sealed record TimestampInvalidError : Error
    {
        public TimestampInvalidError(string timestamp, Origin origin)
            : base($"The timestamp {timestamp} is invalid.", origin) { }
    }
}