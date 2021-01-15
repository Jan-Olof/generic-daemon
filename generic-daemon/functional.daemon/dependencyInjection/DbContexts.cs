using Functional.Common.DataTypes.Validate;
using Functional.Infrastructure.Store.Context;
using System;

namespace Functional.Daemon.DependencyInjection
{
    public class DbContexts : IDbContexts
    {
        public DbContexts(ConnectionStrings connectionStrings)
        {
            // TODO: Init GetDbContext.
        }

        public Func<Validate<GenericDbContext>> GetDbContext { get; }
    }
}