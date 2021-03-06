﻿using Functional.Common.Entities.Messages;
using LanguageExt;
using System;
using static LanguageExt.Prelude;

namespace Functional.Core
{
    public static class ProcessMessage
    {
        public static Func<Message, Unit> Process(Func<DateTime> now, Func<Guid> guid) =>
            message => ProcessOneMessage(message, now, guid);

        private static Unit ProcessOneMessage(Message message, Func<DateTime> now, Func<Guid> guid)
        {
            var oneMessage = message.CreateRequest()
                .Match(
                    request => request.RunInteractor(now, guid),
                    () => unit);

            return oneMessage; // TODO: Fix ProcessOneMessage when interactor returns something.
        }
    }
}