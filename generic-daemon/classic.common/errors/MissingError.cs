using System;

namespace classic.common.errors
{
    public sealed class MissingError : GenericError
    {
        public MissingError(string type, string origin) : base(origin, nameof(MissingError)) =>
            Message = SetMessage(type);

        public MissingError(string info, string type, string origin) : base(origin, nameof(MissingError)) =>
            Message = SetMessage(type);

        public MissingError(Guid entityId, string type, string origin) : base(entityId, origin, nameof(MissingError)) =>
            Message = SetMessage(type);

        private MissingError(Guid entityId, MissingError e) : base(entityId, e.Origin, nameof(MissingError)) =>
            Message = e.Message;

        public override string Message { get; }

        /// <inheritdoc/>
        public override GenericError Create(Guid entityId) =>
            new MissingError(entityId, this);

        private string SetMessage(string type) =>
            $"{type} missing. {Origin}";

        private string SetMessage(string info, string type) =>
            $"Info: {info}. Type {type} is missing. {Origin}";
    }
}