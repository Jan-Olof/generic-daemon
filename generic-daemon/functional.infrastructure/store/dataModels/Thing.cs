using System;

namespace Functional.Infrastructure.Store.DataModels
{
    public record Thing
    {
        private Thing(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; init; }

        public string Name { get; init; }

        public static Thing Create(Guid id, string name) =>
            new(id, name);
    }
}