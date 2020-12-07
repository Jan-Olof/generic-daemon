using functional.common.valueObjects.validation;
using functional.core.requests;
using System;

namespace functional.core.commands
{
    public static class CommandFactory
    {
        public static Validation<Command> CreateCommand(this Request request, Func<DateTime> now, Func<Guid> guid) =>
            request switch
            {
                Add add => AddThing.Create(now, guid, add.Name), // TODO: Finish this.
                Remove remove => throw new NotImplementedException(),
                Update update => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(request)), // TODO: Handle this.
            };
    }
}