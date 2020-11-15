using classic.common.valueObjects;
using LaYumba.Functional;
using System;

namespace classic.core.commands
{
    public class AddThing : Command
    {
        /// <inheritdoc />
        private AddThing(Guid entityId, Timestamp created, string name) : base(entityId, created)
        {
            Name = name;
        }

        public string Name { get; }

        public static Validation<AddThing> Create(Guid entityId, Timestamp created, string name)
        {
            // TODO: Func<DateTime> now, Func<Guid> createId
            throw new NotImplementedException();
            // return new AddThing(entityId, created, name);
        }
    }
}