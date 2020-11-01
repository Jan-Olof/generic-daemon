using common;
using core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace c_sharp_la_yumba
{
    public static class Startup
    {
        public static IHostBuilder CreateBuilder()
        {
            var configuration = ConfigurationHelper.GetConfiguration();

            return new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IMessageHandling, FakeMessageHandling>();
                    services.AddHostedService<Daemon>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(configuration.GetSection("Logging"));
                    logging.AddConsole();
                });
        }
    }
}