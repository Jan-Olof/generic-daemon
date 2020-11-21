using classic.common.time;
using LaYumba.Functional;
using System;

namespace classic.core.commands
{
    public record AddThing : Command
    {
        /// <inheritdoc />
        private AddThing(Guid entityId, Timestamp created, string name) : base(entityId, created)
        {
            Name = name;
        }

        public string Name { get; }

        public static Validation<Command> Create(Func<DateTime> now, Func<Guid> entityId, string name)
        {
            const string origin = nameof(AddThing);

            var created = Timestamp.Create(now(), origin);

            // TODO: HERE!

            throw new NotImplementedException();
            // return new AddThing(entityId, created, name);
        }
    }
}