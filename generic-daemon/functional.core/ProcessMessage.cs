using functional.common.entities.messages;
using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace functional.core
{
    public static class ProcessMessage
    {
        public static Func<Message, Unit> Process(Func<DateTime> now, Func<Guid> guid) =>
            message => ProcessOneMessage(message, now, guid);

        private static Unit ProcessOneMessage(Message message, Func<DateTime> now, Func<Guid> guid)
        {
            var x = message.MessageToRequest()
                .Match(
                    request => request.RunInteractor(now, guid),
                    () => unit);

            return unit; // TODO: Fix ProcessOneMessage when interactor returns something.
        }
    }
}