using classic.common.helpers;
using classic.common.strings;
using classic.common.time;
using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

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

            return IsValid(created, nameVal)
                ? Valid<Command>(new AddThing(id, created.GetObject(), nameVal.GetObject()))
                : Invalid(GetErrors(created, nameVal));
        }

        private static IReadOnlyList<Error> GetErrors(
            Validation<Timestamp> created,
            Validation<Text> name) =>
                new List<Error>()
                    .AddMany(created.GetErrors())
                    .AddMany(name.GetErrors());

        private static bool IsValid(
            Validation<Timestamp> created,
            Validation<Text> name) =>
                created.IsValid && name.IsValid;
    }
}