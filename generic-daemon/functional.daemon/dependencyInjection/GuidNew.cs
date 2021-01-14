using System;

namespace functional.daemon.dependencyInjection
{
    public class GuidNew : IGuid
    {
        /// <inheritdoc />
        public Func<Guid> GetGuid { get; } = Guid.NewGuid;
    }
}