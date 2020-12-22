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
        private AddThing(Guid id, Timestamp created, Text name) : base(id, created) =>
            Name = name;

        public Text Name { get; }

        /// <summary>
        /// Create a new Validate object.
        /// </summary>
        public static Validate<Command> Create(Func<DateTime> now, Func<Guid> guid, string name) // TODO: Page 198: 8.5.2
        {
            var origin = Origin.Create(nameof(AddThing), nameof(Create));

            var created = Timestamp.Create(now(), origin);
            var nameVal = Text.CreateAndValidate(name, origin);

            return IsValid(created, nameVal) // TODO: Fix this!
                ? V.Valid<Command>(new AddThing(guid(), created.GetOrException(), nameVal.GetOrException()))
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