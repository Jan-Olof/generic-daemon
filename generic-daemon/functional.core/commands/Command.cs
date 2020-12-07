using System;
using functional.common.valueObjects;

namespace functional.core.commands
{
    public abstract record Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        protected Command(Guid entityId, Timestamp created)
        {
            EntityId = entityId;
            Created = created;
        }

        public Timestamp Created { get; }

        public Guid EntityId { get; }
    }
}