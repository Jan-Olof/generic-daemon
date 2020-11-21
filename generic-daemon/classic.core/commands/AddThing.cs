using classic.common.strings;
using classic.common.time;
using LaYumba.Functional;
using System;

namespace classic.core.commands
{
    public record AddThing : Command
    {
        /// <inheritdoc />
        private AddThing(Guid entityId, Timestamp created, Text name) : base(entityId, created)
        {
            Name = name;
        }

        public Text Name { get; }

        public static Validation<Command> Create(Func<DateTime> now, Func<Guid> guid, string name)
        {
            const string origin = nameof(AddThing);

            var created = Timestamp.Create(now(), origin);
            var id = guid();
            var nameVal = Text.CreateAndValidate(name, origin);

            var x = IsValid(created, nameVal); // TODO: HERE!

            throw new NotImplementedException();
            // return new AddThing(entityId, created, name);
        }

        private static bool IsValid(
            Validation<Timestamp> created,
            Validation<Text> name) =>
                created.IsValid && name.IsValid;
    }
}