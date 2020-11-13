﻿using classic.common.helpers;
using classic.common.messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace c_sharp_la_yumba
{
    public static class Startup
    {
        public static IHostBuilder CreateBuilder() =>
            new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IMessageHandling, FakeMessageHandling>();
                    services.AddHostedService<Daemon>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(ConfigurationHelper.GetConfiguration().GetSection("Logging"));
                    logging.AddConsole();
                });
    }
}