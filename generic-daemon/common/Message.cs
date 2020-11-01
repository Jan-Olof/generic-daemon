using System;

namespace common
{
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message" /> class.
        /// </summary>
        private Message(DateTime created, string data, MessageTypes type)
        {
            Created = created;
            Data = data;
            Type = type;
        }

        public DateTime Created { get; }

        public string Data { get; }

        public MessageTypes Type { get; }

        public static Message Create(DateTime created, string data, MessageTypes type) =>
            new Message(created, data, type);
    }
}