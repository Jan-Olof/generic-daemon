using System;

namespace classic.common.time
{
    public class NowUtc : INow
    {
        /// <inheritdoc />
        public Func<DateTime> Now { get; } = () => DateTime.UtcNow;
    }
}