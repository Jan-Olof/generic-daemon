using classic.common.messages;
using System;
using Unit = System.ValueTuple;

namespace classic.core
{
    public static class ProcessMessage
    {
        public static Func<Message, Unit> Process() =>
            message => ProcessOneMessage(message);

        public static Unit ProcessOneMessage(Message message) =>
            throw new NotImplementedException();
    }
}