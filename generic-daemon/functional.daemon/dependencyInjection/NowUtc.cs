using System;

namespace functional.daemon.dependencyInjection
{
    public class NowUtc : INow
    {
        /// <inheritdoc />
        public Func<DateTime> Now { get; } = () => DateTime.UtcNow;
    }
}