using Funda.HouseListingsAssignment.Services.Configurations;
using Funda.HouseListingsAssignment.Services.Contracts;
using Funda.HouseListingsAssignment.Services.Contracts.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Funda.HouseListingsAssignment.Services
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Real estate agents related services
            services.AddTransient<IRealEstateAgentsService, RealEstateAgentsService>();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<IServiceConfiguration, ServicesConfiguration>();
        }
    }
}
