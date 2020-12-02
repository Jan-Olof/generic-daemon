﻿using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace functional.common.errors
{
    public abstract class Error
    {
        protected Error(string message, Origin origin)
        {
            Message = message;
            Origin = origin;
            Exception = None;
        }

        protected Error(Exception exception, string message, Origin origin)
        {
            Message = message;
            Origin = origin;
            Exception = exception;
        }

        public Option<Exception> Exception { get; }

        public string Message { get; }

        public Origin Origin { get; }

        public bool IsException() =>
            Exception.IsSome;

        /// <inheritdoc />
        public override string ToString() =>
            $"{Message} {Origin}";
    }
}