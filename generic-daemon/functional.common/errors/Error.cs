namespace functional.common.errors
{
    public abstract class Error // TODO: Use LanguageExt error instead.
    {
        protected Error(string message, Origin origin)
        {
            Message = message;
            Origin = origin;
        }

        public string Message { get; }

        public Origin Origin { get; }

        /// <inheritdoc />
        public override string ToString() =>
            $"{Message} {Origin}";
    }
}