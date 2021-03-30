using Funda.HouseListingsAssignment.Services.Contracts.Configurations;

namespace Funda.HouseListingsAssignment.Services.Configurations
{
    public class ServicesConfiguration : ConfigurationBase, IServiceConfiguration
    {
        /// <summary>
        /// Gets the configuration section.
        /// </summary>
        /// <param name="configName">Name of the configuration.</param>
        /// <returns></returns>
        public string GetConfigSection(string configName)
        {
            return GetConfiguration().GetSection(configName).Value;
        }
    }
}
