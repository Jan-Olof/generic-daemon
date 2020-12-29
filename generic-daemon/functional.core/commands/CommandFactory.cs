using functional.common.valueObjects.validate;
using functional.core.requests;
using System;

namespace functional.core.commands
{
    public static class CommandFactory
    {
        public static Validate<Command> CreateCommand(this Request request, Func<DateTime> now, Func<Guid> guid) =>
            request switch
            {
                Add add => guid.CreateAddThing(now, add.Name),
                Remove remove => throw new NotImplementedException(),
                Update update => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(request)), // TODO: Handle this.
            };
    }
}