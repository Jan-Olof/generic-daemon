﻿// ReSharper disable UnusedParameter.Local
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Functional.Daemon
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("The daemon has started...");

            await Startup.CreateBuilder().RunConsoleAsync();
        }
    }
}