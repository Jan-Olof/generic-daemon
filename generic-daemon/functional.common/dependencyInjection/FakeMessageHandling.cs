using functional.common.entities.messages;
using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace functional.common.dependencyInjection
{
    public sealed record FakeMessageHandling : IMessageHandling
    {
        /// <inheritdoc />
        public Unit HandleMessages(Func<Message, Unit> processMessage)
        {
            processMessage(Message.Create(Guid.Parse("6b7b395b-ecad-4029-96ea-cc6ccfefe464"), "{\"id\": \"5998b4d5-ff78-415f-9ffa-62df1e27dfe8\",\"name\": \"Jane Doe\"}", new DateTime(2000, 1, 1), MessageTypes.NewThing));
            return unit;
        }
    }
}