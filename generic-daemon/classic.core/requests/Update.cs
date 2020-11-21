// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace classic.core.requests
{
    public record Update : Request
    {
        public Update() => Name = string.Empty;

        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}