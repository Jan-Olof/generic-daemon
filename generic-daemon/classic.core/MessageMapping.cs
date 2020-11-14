using classic.common.helpers;
using classic.common.messages;
using classic.core.requests;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace classic.core
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
                .Match(() => (Option<Request>)None, y => y);
    }
}