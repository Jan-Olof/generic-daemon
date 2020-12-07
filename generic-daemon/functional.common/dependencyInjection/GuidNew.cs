using System;
using functional.common.unique_Identifier;

namespace functional.common.dependencyInjection
{
    public class GuidNew : IGuid
    {
        /// <inheritdoc />
        public Func<Guid> GetGuid { get; } = Guid.NewGuid;
    }
}