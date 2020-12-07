using System;

namespace functional.common.dependencyInjection
{
    public interface INow
    {
        /// <summary>
        /// Get a function that returns current time.
        /// </summary>
        Func<DateTime> Now { get; }
    }
}