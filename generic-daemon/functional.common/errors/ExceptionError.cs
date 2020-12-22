using System;

namespace functional.common.errors
{
    public sealed record ExceptionError : Error
    {
        public ExceptionError(Exception exception, Origin origin)
            : base(exception, exception.Message, origin) { }
    }
}