using System;
using Unit = System.ValueTuple;

namespace common
{
    public interface IMessageHandling
    {
        Unit HandleMessages(Func<Message, Unit> processMessage);
    }
}