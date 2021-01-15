using System;

namespace Functional.Daemon.DependencyInjection
{
    public class GuidNew : IGuid
    {
        /// <inheritdoc />
        public Func<Guid> GetGuid { get; } = Guid.NewGuid;
    }
}