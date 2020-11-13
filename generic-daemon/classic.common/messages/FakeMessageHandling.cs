using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace classic.common.messages
{
    public class FakeMessageHandling : IMessageHandling
    {
        /// <inheritdoc />
        public Unit HandleMessages(Func<Message, Unit> processMessage)
        {
            processMessage(Message.Create("{\"id\": \"5998b4d5-ff78-415f-9ffa-62df1e27dfe8\",\"name\": \"Jane Doe\"}", new DateTime(2000, 1, 1), MessageTypes.NewThing));
            return Unit();
        }
    }
}