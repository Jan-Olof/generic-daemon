// ReSharper disable UnusedParameter.Local
using common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace c_sharp_la_yumba
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("The daemon has started...");

            var configuration = ConfigurationHelper.GetConfiguration();

            var builder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Daemon>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            await builder.RunConsoleAsync();
        }
    }
}