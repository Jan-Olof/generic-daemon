﻿using functional.common.helpers;
using functional.infrastructure.store.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace functional.daemon
{
    public class EventStoreDbContextFactory : IDesignTimeDbContextFactory<EventStoreDbContext>
    {
        public EventStoreDbContext CreateDbContext(string[] args)
        {
            string? cs = ConfigurationHelper.GetConfiguration().GetConnectionString("EventStoreDbContext");
            var optionsBuilder = new DbContextOptionsBuilder<EventStoreDbContext>();
            optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs), opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new EventStoreDbContext(optionsBuilder.Options);
        }
    }
}