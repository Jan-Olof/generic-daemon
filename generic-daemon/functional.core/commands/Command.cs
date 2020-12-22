using functional.common.valueObjects;
using System;

namespace functional.core.commands
{
    public abstract record Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        protected Command(Guid id, Timestamp created)
        {
            Id = id;
            Created = created;
        }

        public Timestamp Created { get; }

        public Guid Id { get; }
    }
}