using System;

namespace functional.common.time
{
    public class NowUtc : INow
    {
        /// <inheritdoc />
        public Func<DateTime> Now { get; } = () => DateTime.UtcNow;
    }
}