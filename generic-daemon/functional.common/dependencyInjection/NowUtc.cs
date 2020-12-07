using System;

namespace functional.common.dependencyInjection
{
    public class NowUtc : INow
    {
        /// <inheritdoc />
        public Func<DateTime> Now { get; } = () => DateTime.UtcNow;
    }
}