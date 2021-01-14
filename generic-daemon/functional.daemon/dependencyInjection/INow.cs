using System;

namespace functional.daemon.dependencyInjection
{
    public interface INow
    {
        /// <summary>
        /// Get a function that returns current time.
        /// </summary>
        Func<DateTime> Now { get; }
    }
}