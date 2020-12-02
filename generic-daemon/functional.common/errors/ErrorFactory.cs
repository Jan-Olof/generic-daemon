using System;

namespace functional.common.errors
{
    public static class ErrorFactory
    {
        public static ExceptionError Exception(Exception exception, Origin origin) =>
            new(exception, origin);

        public static MissingError Missing(string type, Origin origin) =>
            new(type, origin);

        public static TimestampInvalidError TimestampInvalid(string timestamp, Origin origin) =>
            new(timestamp, origin);
    }
}