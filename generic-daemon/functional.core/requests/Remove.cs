// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace Functional.Core.Requests
{
    public record Remove : Request
    {
        public Guid Id { get; init; }
    }
}