using System;

namespace Functional.Core.Requests
{
    public abstract record Request
    {
        public Guid MessageId { get; init; }

        /// <summary>
        /// Create a new Request.
        /// </summary>
        public Request Create(Guid messageId) =>
            this with { MessageId = messageId };
    }
}