using System;

namespace classic.common.unique_Identifier
{
    public interface IGuid
    {
        Func<Guid> GetGuid { get; }
    }
}