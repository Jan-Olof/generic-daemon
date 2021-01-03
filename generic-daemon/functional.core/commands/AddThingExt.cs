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
            = Origin.Create(Guid.Empty, nameof(AddThingExt), nameof(CreateAddThing));

        private static readonly Func<Guid, Origin, Validate<Guid>> ValidGuid
            = (guid, origin) => guid.CreateAndValidate(origin);

        private static readonly Func<DateTime, Origin, Validate<Timestamp>> ValidTimestamp
            = Timestamp.Create;

        private static readonly Func<string, Origin, Validate<Text>> ValidName
            = Text.Create;

        /// <summary>
        /// Create a new Validate AddThing object.
        /// </summary>
        public static Validate<Command> CreateAddThing(this Func<Guid> guid, Func<DateTime> now, string name, Guid messageId) =>
            Valid(AddThing.Create)
                .Apply(ValidGuid(guid(), Origin.Create(messageId)))
                .Apply(ValidTimestamp(now(), Origin.Create(messageId)))
                .Apply(ValidName(name, Origin.Create(messageId)));
    }
}