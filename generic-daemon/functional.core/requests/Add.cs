// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Functional.Core.Requests
{
    public record Add : Request
    {
        public Add() =>
            Name = string.Empty;

        public string Name { get; init; }
    }
}