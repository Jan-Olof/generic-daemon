using functional.common.helpers;
using functional.common.valueObjects;
using LaYumba.Functional;
using System;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace functional.core.commands
{
    public record AddThingClassic : Command
    {
        /// <inheritdoc />
        private AddThingClassic(Guid entityId, Timestamp created, Text name) : base(entityId, created) =>
            Name = name;

        public Text Name { get; }

        public static Validation<Command> Create(Func<DateTime> now, Func<Guid> guid, string name)
        {
            const string origin = nameof(AddThingClassic);

            var created = Timestamp.Create(now(), origin);
            var id = guid();
            var nameVal = Text.CreateAndValidate(name, origin);

            return IsValid(created, nameVal)
                ? Valid<Command>(new AddThingClassic(id, created.GetObject(), nameVal.GetObject()))
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