namespace Functional.Common.Errors
{
    public sealed record GuidInvalidError : Error
    {
        public GuidInvalidError(string guid, Origin origin)
            : base($"The GUID {guid} is invalid.", origin) { }
    }
}