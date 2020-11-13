using classic.common.messages;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace classic.core
{
    public static class ProcessMessage
    {
        public static Func<Message, Unit> Process() =>
            ProcessOneMessage;

        private static Unit ProcessOneMessage(Message message)
        {
            var x = message.MessageToRequest();
            return Unit();
        }
    }
}