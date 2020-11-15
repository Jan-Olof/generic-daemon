using System;

namespace classic.common.unique_Identifier
{
    public class GuidNew : IGuid
    {
        /// <inheritdoc />
        public Func<Guid> GetGuid { get; } = Guid.NewGuid;
    }
}