using System;

namespace Functional.Daemon.DependencyInjection
{
    public interface INow
    {
        /// <summary>
        /// Get a function that returns current time.
        /// </summary>
        Func<DateTime> Now { get; }
    }
}