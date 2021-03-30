namespace Funda.HouseListingsAssignment.Services.Contracts.Configurations
{
    public interface IServiceConfiguration
    {
        string GetConfigSection(string configName);
    }
}
