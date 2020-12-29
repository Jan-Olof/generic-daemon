using functional.common.errors;
using functional.common.helpers;
using functional.common.valueObjects;
using functional.common.valueObjects.validate;
using System;
using static functional.common.valueObjects.validate.V;

namespace functional.core.commands
{
    public static class AddThingExt
    {
        private static readonly Origin Origin
            = Origin.Create(nameof(AddThingExt), nameof(CreateAddThing));

        private static readonly Func<Guid, Validate<Guid>> ValidGuid
            = guid => guid.CreateAndValidate(Origin);

        private static readonly Func<DateTime, Validate<Timestamp>> ValidTimestamp
            = dateTime => Timestamp.Create(dateTime, Origin);

        private static readonly Func<string, Validate<Text>> ValidName
            = name => Text.CreateAndValidate(name, Origin);

        /// <summary>
        /// Create a new Validate AddThing object.
        /// </summary>
        public static Validate<Command> CreateAddThing(this Func<Guid> guid, Func<DateTime> now, string name) =>
            Valid(AddThing.Create)
                .Apply(ValidGuid(guid()))
                .Apply(ValidTimestamp(now()))
                .Apply(ValidName(name));
    }
}