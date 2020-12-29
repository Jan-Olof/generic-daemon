using System.Collections.Generic;
using System.Linq;

namespace functional.common.helpers
{
    /// <summary>
    /// Extends IEnumerable.
    /// </summary>
    public static class EnumerableExt
    {
        /// <summary>
        /// Adds an object to the IEnumerable.
        /// </summary>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T n)
        {
            var list = e.ToList();
            list.Add(n);
            return list;
        }

        /// <summary>
        /// Adds the elements to the specified IEnumerable.
        /// </summary>
        public static IEnumerable<T> AddMany<T>(this IEnumerable<T> e, IEnumerable<T> n)
        {
            var list = e.ToList();
            list.AddRange(n);
            return list;
        }

        /// <summary>
        /// Return the elements in t1 that exists in t2.
        /// </summary>
        public static IEnumerable<T> Contains<T>(this IEnumerable<T> t1, IEnumerable<T> t2) =>
            t1.Where(t2.Contains);

        /// <summary>
        /// Create a new IEnumerable.
        /// </summary>
        public static IEnumerable<T> CreateIEnumerable<T>(this T t1) =>
            new List<T> { t1 };

        /// <summary>
        /// Create a new IEnumerable.
        /// </summary>
        public static IEnumerable<T> CreateIEnumerable<T>(this T t1, T t2) =>
            new List<T> { t1, t2 };

        /// <summary>
        /// Create a new IEnumerable.
        /// </summary>
        public static IEnumerable<T> CreateIEnumerable<T>(this T t1, T t2, T t3) =>
            new List<T> { t1, t2, t3 };

        /// <summary>
        /// Create a new IEnumerable.
        /// </summary>
        public static IEnumerable<T> CreateIEnumerable<T>(this T t1, T t2, T t3, T t4) =>
            new List<T> { t1, t2, t3, t4 };

        /// <summary>
        /// Is the IEnumerable null or empty?
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> e) =>
            !e?.Any() ?? true;

        public static IEnumerable<T> ToEnumerable<T>(this List<T> l) => l;

        public static IEnumerable<T> ToEnumerable<T>(this IQueryable<T> q) => q;
    }
}