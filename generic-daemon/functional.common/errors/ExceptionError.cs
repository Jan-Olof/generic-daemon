using System;

namespace Functional.Common.Errors
{
    public sealed record ExceptionError : Error
    {
        public ExceptionError(Exception exception)
            : base(exception) { }

        public ExceptionError(Exception exception, Origin origin)
            : base(exception, exception.Message, origin) { }
    }
}