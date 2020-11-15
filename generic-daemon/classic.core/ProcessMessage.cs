using classic.common.messages;
using System;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace classic.core
{
    public static class ProcessMessage
    {
        public static Func<Message, Unit> Process(Func<DateTime> now, Func<Guid> guid) =>
            message => ProcessOneMessage(message, now, guid);

        private static Unit ProcessOneMessage(Message message, Func<DateTime> now, Func<Guid> guid)
        {
            var x = message.MessageToRequest()
                .Match(
                    () => Unit(),
                    request => request.RunInteractor(now, guid));

            return Unit();
        }
    }
}