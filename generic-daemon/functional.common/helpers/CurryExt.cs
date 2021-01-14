using System;

namespace Functional.Common.Helpers
{
    public static class CurryExt
    {
        public static Func<T1, Func<T2, T3, TR>> CurryFirst<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> @this) =>
            t1 => (t2, t3) => @this(t1, t2, t3);

        public static Func<T1, Func<T2, T3, T4, TR>> CurryFirst<T1, T2, T3, T4, TR>(this Func<T1, T2, T3, T4, TR> @this) =>
            t1 => (t2, t3, t4) => @this(t1, t2, t3, t4);
    }
}