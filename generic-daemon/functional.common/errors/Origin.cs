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
            Message = SetMessage(cls, func, id);
        }

        private Origin(Exception ex)
        {
            Class = string.Empty;
            Function = string.Empty;
            Id = Guid.Empty;
            Message = ex.StackTrace ?? string.Empty;
        }

        public string Class { get; private init; }

        public string Function { get; private init; }

        public string Message { get; private init; }

        public Guid Id { get; private init; }

        public static Origin Create(Exception ex) =>
            new(ex);

        public static Origin Create(Guid id, string cls, string func) =>
            new(id, cls, func);

        public Origin Update(Guid id) =>
            this with { Id = id, Message = SetMessage(Class, Function, id) };

        /// <inheritdoc />
        public override string ToString() =>
            Message;

        private static string SetMessage(string cls, string func, Guid id) =>
            $"Origin: {func} in {cls} with Id: {id}.";
    }
}