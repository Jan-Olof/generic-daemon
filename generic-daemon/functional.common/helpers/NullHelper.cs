using LanguageExt;
using static LanguageExt.Prelude;

namespace functional.common.helpers
{
    public static class NullHelper
    {
        public static Option<T> ToOption<T>(this T? t) where T : class =>
            t != null ? (Option<T>)t : None;
    }
}