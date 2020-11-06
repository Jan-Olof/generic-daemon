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
            processMessage(Message.Create("data", new DateTime(2000, 1, 1), MessageTypes.AddThing));
            return Unit();
        }
    }
}