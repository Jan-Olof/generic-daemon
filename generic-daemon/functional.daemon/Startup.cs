using functional.common.helpers;
using functional.common.messages;
using functional.common.time;
using functional.common.unique_Identifier;
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
                    services.AddSingleton<IMessageHandling, FakeMessageHandling>();
                    services.AddSingleton<INow, NowUtc>();
                    services.AddSingleton<IGuid, GuidNew>();
                    services.AddHostedService<Daemon>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(ConfigurationHelper.GetConfiguration().GetSection("Logging"));
                    logging.AddConsole();
                });
    }
}