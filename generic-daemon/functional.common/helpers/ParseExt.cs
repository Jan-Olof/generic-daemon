using LanguageExt;
using static LanguageExt.Prelude;

namespace Functional.Common.Helpers
{
    public static class ParseExt
    {
        public static Option<T> Parse<T>(this string s) where T : struct =>
            System.Enum.TryParse(s, out T t) ? Some(t) : None;
    }
}