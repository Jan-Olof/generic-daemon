using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace common
{
    public class FakeMessageHandling : IMessageHandling
    {
        /// <inheritdoc />
        public Unit HandleMessages(Func<Message, Unit> processMessage)
        {
            processMessage(Message.Create(new DateTime(2000, 1, 1), "data", MessageTypes.Empty));
            return Unit();
        }
    }
}