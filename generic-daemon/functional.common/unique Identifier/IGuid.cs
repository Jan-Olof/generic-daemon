using System;

namespace functional.common.unique_Identifier
{
    public interface IGuid
    {
        Func<Guid> GetGuid { get; }
    }
}