using System;

namespace functional.infrastructure.store.dataModels
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