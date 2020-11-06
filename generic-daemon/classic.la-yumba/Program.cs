// ReSharper disable UnusedParameter.Local
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace c_sharp_la_yumba
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("The daemon has started...");

            await Startup.CreateBuilder().RunConsoleAsync();
        }
    }
}