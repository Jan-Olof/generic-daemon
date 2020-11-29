namespace functional.common.errors
{
    public sealed class MissingError : Error
    {
        public MissingError(string type, Origin origin)
            : base($"{type} missing.", origin) { }
    }
}