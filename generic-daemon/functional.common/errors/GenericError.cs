using System;
using LaYumba.Functional;

namespace functional.common.errors
{
    public abstract class GenericError : Error
    {
        protected GenericError(string origin, string errorType)
        {
            Origin = SetOrigin(origin);
            EntityId = Guid.Empty;
            ErrorType = errorType;
        }

        protected GenericError(Guid entityId, string origin, string errorType)
        {
            Origin = SetOrigin(origin);
            EntityId = entityId;
            ErrorType = errorType;
        }

        public Guid EntityId { get; }

        public string ErrorType { get; }

        protected string Origin { get; }

        /// <summary>
        /// Create a new GenericError from this error and an entity id.
        /// </summary>
        public abstract GenericError Create(Guid entityId);

        private static string SetOrigin(string origin) =>
            origin.Contains("Origin: ") ? origin : $"Origin: {origin}.";
    }
}