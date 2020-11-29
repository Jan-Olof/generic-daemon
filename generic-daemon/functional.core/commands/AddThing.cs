using functional.common.strings;
using functional.common.time;
using LanguageExt;
using System;

namespace functional.core.commands
{
    public record AddThing : Command
    {
        /// <inheritdoc />
        private AddThing(Guid entityId, Timestamp created, Text name) : base(entityId, created) =>
            Name = name;

        public Text Name { get; }

        public static Validation<Command, Command> Create(Func<DateTime> now, Func<Guid> guid, string name)
        {
            const string origin = nameof(AddThing);

            var created = Timestamp.Create(now(), origin);
            var id = guid();
            var nameVal = Text.CreateAndValidate(name, origin);

            // TODO: Return here.
            //return IsValid(created, nameVal)
            //    ? Valid<Command>(new AddThing(id, created.GetObject(), nameVal.GetObject()))
            //    : Invalid(GetErrors(created, nameVal));

            throw new NotImplementedException();
        }

        //private static IReadOnlyList<Error> GetErrors(
        //    Validation<Timestamp> created,
        //    Validation<Text> name) =>
        //        new List<Error>()
        //            .AddMany(created.GetErrors())
        //            .AddMany(name.GetErrors());

        //private static bool IsValid(
        //    Validation<Timestamp> created,
        //    Validation<Text> name) =>
        //        created.IsValid && name.IsValid;
    }
}