using classic.common.valueObjects;
using System;

namespace classic.core.commands
{
    public abstract class Command
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