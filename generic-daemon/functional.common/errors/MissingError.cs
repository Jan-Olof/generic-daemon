namespace functional.common.errors
{
    public sealed record MissingError : Error
    {
        public MissingError(string type, Origin origin)
            : base($"{type} missing.", origin) { }
    }
}