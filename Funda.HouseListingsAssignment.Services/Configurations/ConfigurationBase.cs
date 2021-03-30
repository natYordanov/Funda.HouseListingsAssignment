using System;
using Microsoft.Extensions.Configuration;

namespace Funda.HouseListingsAssignment.Services.Configurations
{
    public class ConfigurationBase
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns></returns>
        protected IConfigurationRoot GetConfiguration() => new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        /// <summary>
        /// Raises the value not found exception.
        /// </summary>
        /// <param name="configurationKey">The configuration key.</param>
        /// <exception cref="System.Exception">appsettings key ({configurationKey}) could not be found.</exception>
        protected void RaiseValueNotFoundException(string configurationKey)
        {
            throw new Exception($"appsettings key ({configurationKey}) could not be found.");
        }
    }
}
