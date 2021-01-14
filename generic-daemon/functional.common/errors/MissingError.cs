namespace Functional.Common.Errors
{
    public sealed record MissingError : Error
    {
        public MissingError(string type, Origin origin)
            : base($"{type} missing.", origin) { }
    }
}