using System;

namespace Functional.Common.Entities.Messages
{
    public sealed record Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        private Message(Guid messageId, string data, DateTime timestamp, MessageTypes type)
        {
            Data = data;
            MessageId = messageId;
            Timestamp = timestamp;
            Type = type;
        }

        public string Data { get; }

        public Guid MessageId { get; }

        public DateTime Timestamp { get; }

        public MessageTypes Type { get; }

        public static Message Create(Guid messageId, string data, DateTime timestamp, MessageTypes type) =>
            new Message(messageId, data, timestamp, type);
    }
}