// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace classic.core.requests
{
    public record Remove : Request
    {
        public Guid Id { get; init; }
    }
}