using System;

namespace Functional.Common.Errors
{
    public static class ErrorFactory
    {
        public static ExceptionError Exception(Exception exception, Origin origin) =>
            new(exception, origin);

        public static GuidInvalidError GuidInvalid(string guid, Origin origin) =>
            new(guid, origin);

        public static MissingError Missing(string type, Origin origin) =>
            new(type, origin);

        public static TextInvalidError TextInvalid(string text, Origin origin) =>
            new(text, origin);

        public static TimestampInvalidError TimestampInvalid(string timestamp, Origin origin) =>
            new(timestamp, origin);
    }
}