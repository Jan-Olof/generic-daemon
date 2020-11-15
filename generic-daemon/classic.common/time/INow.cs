using System;

namespace classic.common.time
{
    public interface INow
    {
        /// <summary>
        /// Get a function that returns current time.
        /// </summary>
        Func<DateTime> Now { get; }
    }
}