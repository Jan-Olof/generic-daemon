namespace functional.common.errors
{
    public sealed record TextInvalidError : Error
    {
        public TextInvalidError(string text, Origin origin)
            : base($"The Text {text} is invalid.", origin) { }
    }
}