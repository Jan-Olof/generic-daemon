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
        /// Adds the elements to the specified IEnumerable.
        /// </summary>
        public static IReadOnlyList<T> AddMany<T>(this IReadOnlyList<T> e, IEnumerable<T> n)
        {
            var list = e.ToList();
            list.AddRange(n);
            return list;
        }
    }
}