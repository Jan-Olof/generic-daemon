namespace classic.common.errors
{
    public static class ErrorFactory
    {
        public static TimestampInvalidError TimestampInvalid(string timestamp, string origin) =>
            new TimestampInvalidError(timestamp, origin);
    }
}