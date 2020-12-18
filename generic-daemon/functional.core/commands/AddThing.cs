using functional.common.errors;
using functional.common.helpers;
using functional.common.valueObjects;
using functional.common.valueObjects.validation;
using System;
using System.Collections.Generic;

namespace functional.core.commands
{
    public record AddThing : Command
    {
        /// <inheritdoc />
        private AddThing(Guid entityId, Timestamp created, Text name) : base(entityId, created) =>
            Name = name;

        public Text Name { get; }

        public static Validation<Command> Create(Func<DateTime> now, Func<Guid> guid, string name)
        {
            var origin = Origin.Create(nameof(Timestamp), nameof(Create));

            var created = Timestamp.Create(now(), origin);
            var id = guid();
            var nameVal = Text.CreateAndValidate(name, origin);

            return IsValid(created, nameVal)
                ? V.Valid<Command>(new AddThing(id, created.GetObject(), nameVal.GetObject()))
                : V.Invalid(GetErrors(created, nameVal));
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