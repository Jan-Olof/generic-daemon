namespace functional.common.errors
{
    public record Origin
    {
        private Origin(string cls, string func)
        {
            Class = cls;
            Function = func;
        }

        public string Class { get; }

        public string Function { get; }

        public static Origin Create(string cls, string func) =>
            new Origin(cls, func);

        /// <inheritdoc />
        public override string ToString() =>
            $"$Origin: {Function} in {Class}.";
    }
}