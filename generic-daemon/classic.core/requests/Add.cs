// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace classic.core.requests
{
    public record Add : Request
    {
        public Add() => Name = string.Empty;

        public string Name { get; init; }
    }
}