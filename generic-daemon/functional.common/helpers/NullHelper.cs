using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace functional.common.helpers
{
    public static class NullHelper
    {
        public static Option<T> ToOption<T>(this T? t) where T : class =>
            t != null ? (Option<T>)t : None;
    }
}