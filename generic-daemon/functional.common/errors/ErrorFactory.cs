using System;

namespace Functional.Common.Errors
{
    public static class ErrorFactory
    {
        public static ExceptionError CreateExceptionError(this Exception exception) =>
            new(exception);

        public static ExceptionError CreateExceptionError(this Exception exception, Origin origin) =>
            new(exception, origin);

        public static GuidInvalidError CreateGuidInvalidError(this string guid, Origin origin) =>
            new(guid, origin);

        public static MissingError CreateMissingError(this string type, Origin origin) =>
            new(type, origin);

        public static TextInvalidError CreateTextInvalidError(this string text, Origin origin) =>
            new(text, origin);

        public static TimestampInvalidError CreateTimestampInvalidError(this string timestamp, Origin origin) =>
            new(timestamp, origin);
    }
}