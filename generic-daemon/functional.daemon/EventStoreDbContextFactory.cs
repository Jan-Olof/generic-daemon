using Functional.Infrastructure.Store.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using Functional.Common.Helpers;

namespace Functional.Daemon
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