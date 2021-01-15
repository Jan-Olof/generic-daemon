using System;

namespace Functional.Daemon.DependencyInjection
{
    public class NowUtc : INow
    {
        /// <inheritdoc />
        public Func<DateTime> Now { get; } = () => DateTime.UtcNow;
    }
}