namespace functional.common.errors
{
    public sealed record GuidInvalidError : Error
    {
        public GuidInvalidError(string guid, Origin origin)
            : base($"The GUID {guid} is invalid.", origin) { }
    }
}