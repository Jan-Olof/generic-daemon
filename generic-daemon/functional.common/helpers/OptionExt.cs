using System;
using LanguageExt;

namespace Functional.Common.Helpers
{
    public static class OptionExt
    {
        /// <summary>
        /// Get the object, or throw InvalidOperationException. (So, this can only be used when we know that the object is Some.)
        /// </summary>
        public static T GetOrException<T>(this Option<T> option) =>
            option.Match(t => t, () => throw new InvalidOperationException("The object is None."));
    }
}