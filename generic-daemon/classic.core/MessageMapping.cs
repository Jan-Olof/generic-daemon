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
                MessageTypes.NewThing => None, // TODO: Fix here!
                MessageTypes.ThingRemoved => None,
                MessageTypes.ThingChanged => None,
                _ => None
            };
    }
}