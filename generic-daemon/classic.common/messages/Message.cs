using System;

namespace classic.common.messages
{
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        private Message(string data, DateTime timestamp, MessageTypes type)
        {
            Data = data;
            Timestamp = timestamp;
            Type = type;
        }

        public string Data { get; }

        public DateTime Timestamp { get; }

        public MessageTypes Type { get; }

        public static Message Create(string data, DateTime timestamp, MessageTypes type) =>
            new Message(data, timestamp, type);
    }
}