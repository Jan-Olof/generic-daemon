using Functional.Common.DataTypes.Validate;
using functional.infrastructure.store.context;
using System;

namespace functional.daemon.dependencyInjection
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