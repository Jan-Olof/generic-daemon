using Functional.Common.DataTypes.Validate;
using Functional.Infrastructure.Store.Context;
using System;

namespace Functional.Daemon.DependencyInjection
{
    public interface IDbContexts
    {
        /// <summary>
        /// Get a function that returns a Validate GenericDbContext.
        /// </summary>
        Func<Validate<GenericDbContext>> GetDbContext { get; }
    }
}