using System;

namespace functional.common.unique_Identifier
{
    public class GuidNew : IGuid
    {
        /// <inheritdoc />
        public Func<Guid> GetGuid { get; } = Guid.NewGuid;
    }
}