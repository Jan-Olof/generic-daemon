using Functional.Common.Helpers;
using functional.infrastructure.store.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace functional.daemon
{
    public class EventStoreDbContextFactory : IDesignTimeDbContextFactory<GenericDbContext>
    {
        public GenericDbContext CreateDbContext(string[] args)
        {
            string? cs = ConfigurationHelper.GetConfiguration().GetConnectionString("GenericDbContext");
            var optionsBuilder = new DbContextOptionsBuilder<GenericDbContext>();
            optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new GenericDbContext(optionsBuilder.Options);
        }
    }
}