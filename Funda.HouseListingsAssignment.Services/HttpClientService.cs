using System;
using System.Net.Http;
using Funda.HouseListingsAssignment.Services.Constants;
using Funda.HouseListingsAssignment.Services.Contracts;
using Funda.HouseListingsAssignment.Services.Contracts.Configurations;

namespace Funda.HouseListingsAssignment.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IServiceConfiguration _serviceConfiguration;

        public HttpClientService(IServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration;
        }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        public HttpClient GetHttpClient()
        {
            var productApi = _serviceConfiguration.GetConfigSection(RealEstateConstants.FundaApi);

            return new HttpClient { BaseAddress = new Uri(productApi) };
        }
    }
}
