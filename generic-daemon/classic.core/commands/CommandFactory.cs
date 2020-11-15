using classic.core.requests;
using LaYumba.Functional;
using System;

namespace classic.core.commands
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