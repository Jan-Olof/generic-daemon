using LanguageExt;
using static LanguageExt.Prelude;

namespace Functional.Common.Helpers
{
    public static class NullHelper
    {
        public static Option<T> ToOption<T>(this T? t) where T : class =>
            t != null ? (Option<T>)t : None;
    }
}