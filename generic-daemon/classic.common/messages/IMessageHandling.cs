using System;
using Unit = System.ValueTuple;

namespace classic.common.messages
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}