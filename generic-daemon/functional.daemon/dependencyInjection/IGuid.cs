using System;

namespace functional.daemon.dependencyInjection
{
    public interface IGuid
    {
        Func<Guid> GetGuid { get; }
    }
}