using functional.common.entities.messages;
using functional.common.helpers;
using functional.core.requests;
using LanguageExt;
using static LanguageExt.Prelude;

namespace functional.core
{
    public static class MessageMapping
    {
        public static Option<Request> MessageToRequest(this Message message) =>
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