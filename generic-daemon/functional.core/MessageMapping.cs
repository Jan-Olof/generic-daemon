﻿using Functional.Common.Entities.Messages;
using Functional.Common.Helpers;
using Functional.Core.Requests;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Functional.Core
{
    public static class MessageMapping
    {
        public static Option<Request> CreateRequest(this Message message) =>
            message.Type switch
            {
                MessageTypes.NewThing => DeserializeToRequest<Add>(message),
                MessageTypes.ThingRemoved => DeserializeToRequest<Remove>(message),
                MessageTypes.ThingChanged => DeserializeToRequest<Update>(message),
                _ => None
            };

        private static Option<Request> DeserializeToRequest<T>(Message message) where T : Request =>
            message.Data.Deserialize<T>()
                .Map(request => request.Create(message.MessageId));
    }
}