using Functional.Common.DataTypes.Validate;
using functional.infrastructure.store.context;
using System;

namespace functional.daemon.dependencyInjection
{
    public interface IDbContexts
    {
        /// <summary>
        /// Get a function that returns a Validate GenericDbContext.
        /// </summary>
        Func<Validate<GenericDbContext>> GetDbContext { get; }
    }
}