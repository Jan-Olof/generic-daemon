using System;

namespace functional.common.errors
{
    public static class ErrorFactory
    {
        public static MissingError Missing(Guid entityId, string type, string origin) =>
            new MissingError(entityId, type, origin);

        public static MissingError Missing(string info, string type, string origin) =>
            new MissingError(info, type, origin);

        public static MissingError Missing(string type, string origin) =>
            new MissingError(type, origin);

        public static TimestampInvalidError TimestampInvalid(string timestamp, string origin) =>
            new TimestampInvalidError(timestamp, origin);
    }
}