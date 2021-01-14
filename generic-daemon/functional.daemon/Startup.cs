﻿using Functional.Common.Helpers;
using functional.daemon.dependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace functional.daemon
{
    public static class Startup
    {
        public static IHostBuilder CreateBuilder() =>
            new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(ConnectionStrings.Create(ConfigurationHelper.GetConfiguration().GetConnectionString("GenericDbContext")));
                    services.AddSingleton<IMessageHandling, FakeMessageHandling>();
                    services.AddSingleton<INow, NowUtc>();
                    services.AddSingleton<IGuid, GuidNew>();
                    services.AddSingleton<IDbContexts, DbContexts>();
                    services.AddHostedService<Daemon>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(ConfigurationHelper.GetConfiguration().GetSection("Logging"));
                    logging.AddConsole();
                });
    }
}