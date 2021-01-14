using System;

namespace Functional.Common.Errors
{
    public record Origin
    {
        private Origin(Guid id, string cls, string func)
        {
            Class = cls;
            Function = func;
            Id = id;
        }

        public string Class { get; private init; }

        public string Function { get; private init; }

        public Guid Id { get; private init; }

        public static Origin Create(Guid id, string cls, string func) =>
            new(id, cls, func);

        public Origin Create(Guid id) =>
            this with { Id = id };

        /// <inheritdoc />
        public override string ToString() =>
            $"Origin: {Function} in {Class} with Id: {Id}.";
    }
}