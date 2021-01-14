using Functional.Common.DataTypes.Validate;
using Functional.Common.Errors;
using functional.core.requests;
using System;
using static Functional.Common.DataTypes.Validate.V;

namespace functional.core.commands
{
    public static class CommandFactory
    {
        public static Validate<Command> CreateCommand(this Request request, Func<DateTime> now, Func<Guid> guid) =>
            request switch
            {
                Add add => guid.CreateAddThing(now, add.Name, request.MessageId),
                Remove remove => throw new NotImplementedException(),
                Update update => throw new NotImplementedException(),
                _ => ArgumentOutOfRange(request)
            };

        private static Validate<Command> ArgumentOutOfRange(Request request) =>
            Invalid(ErrorFactory.Exception(
                new ArgumentOutOfRangeException(nameof(request)),
                Origin.Create(request.MessageId, nameof(CommandFactory), nameof(CreateCommand))));
    }
}