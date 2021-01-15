using System;

namespace Functional.Daemon.DependencyInjection
{
    public interface IGuid
    {
        Func<Guid> GetGuid { get; }
    }
}