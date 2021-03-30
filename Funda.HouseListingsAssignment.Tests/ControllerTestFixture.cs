using System;
using Funda.HouseListingsAssignment.Services;
using Funda.HouseListingsAssignment.Services.Configurations;
using Funda.HouseListingsAssignment.Services.Contracts;
using Funda.HouseListingsAssignment.Services.Contracts.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Funda.HouseListingsAssignment.Tests
{
    public class ControllerTestFixture : IDisposable
    {
        private readonly IHost _host;
        public ServiceProvider ServiceProvider { get; private set; }

        public ControllerTestFixture()
        {
            _host = new HostBuilder()
                   .ConfigureWebHostDefaults(
                        b => b.UseUrls("http://localhost:5001")
                              .UseStartup<ControllerTestStartup>()
                    )
                   .Build();

            _host.Start();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IServiceConfiguration, ServicesConfiguration>();
            serviceCollection.AddTransient<IHttpClientService, HttpClientService>();
            serviceCollection.AddTransient<IRealEstateAgentsService, RealEstateAgentsService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose() => _host.Dispose();
    }
}