using System;

namespace functional.common.errors
{
    public sealed class ExceptionError : Error
    {
        public ExceptionError(Exception exception, Origin origin)
            : base(exception, exception.Message, origin) { }
    }
}