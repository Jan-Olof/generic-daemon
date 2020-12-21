using functional.common.errors;
using functional.common.helpers;
using functional.common.valueObjects;
using functional.common.valueObjects.validate;
using System;
using System.Collections.Generic;

namespace functional.core.commands
{
    public record AddThing : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddThing" /> class.
        /// </summary>
        private AddThing(Guid entityId, Timestamp created, Text name) : base(entityId, created) =>
            Name = name;

        public Text Name { get; }

        public static Validate<Command> Create(Func<DateTime> now, Func<Guid> guid, string name)
        {
            var origin = Origin.Create(nameof(Timestamp), nameof(Create));

            var created = Timestamp.Create(now(), origin);
            var id = guid();
            var nameVal = Text.CreateAndValidate(name, origin);

            return IsValid(created, nameVal) // TODO: Fix this!
                ? V.Valid<Command>(new AddThing(id, created.GetOrException(), nameVal.GetOrException()))
                : V.Invalid(GetErrors(created, nameVal));
        }

        private static IReadOnlyList<Error> GetErrors(
            Validate<Timestamp> created,
            Validate<Text> name) =>
                new List<Error>()
                    .AddMany(created.GetErrors())
                    .AddMany(name.GetErrors());

        private static bool IsValid(
            Validate<Timestamp> created,
            Validate<Text> name) =>
                created.IsValid && name.IsValid;
    }
}