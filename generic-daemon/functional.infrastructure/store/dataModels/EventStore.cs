using System;
using Functional.Common.Entities.Messages;

namespace Functional.Infrastructure.Store.DataModels
{
    public record EventStore
    {
        ///// <summary>
        ///// Initializes a new instance of the <see cref="EventStore" /> class.
        ///// </summary>
        //[Obsolete("Default constructor only here for the ORM", true)]
        //public EventStore()
        //{
        //    Timestamp = DateTimes.Default();
        //    Data = string.Empty;
        //}

        private EventStore(string data, MessageTypes messageType, DateTime timestamp, Guid entityId)
        {
            Data = data;
            MessageType = messageType;
            Timestamp = timestamp;
            EntityId = entityId;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public string Data { get; init; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        public Guid EntityId { get; init; }

        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        public MessageTypes MessageType { get; init; }

        /// <summary>
        /// Gets or sets the id. This is the primary key.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        public DateTime Timestamp { get; init; }

        public static EventStore Create(string data, MessageTypes eventType, DateTime timestamp, Guid entityId) =>
            new EventStore(data, eventType, timestamp, entityId);
    }
}