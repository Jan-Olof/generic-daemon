﻿using Microsoft.Extensions.Configuration;

namespace Functional.Common.Helpers
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Get configuration from the settings file.
        /// </summary>
        public static IConfigurationRoot GetConfiguration(string settingsFile = "appsettings.json")
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(settingsFile, false);
            return builder.Build();
        }
    }
}