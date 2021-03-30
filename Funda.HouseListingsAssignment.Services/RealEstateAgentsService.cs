using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Funda.HouseListingsAssignment.Models;
using Funda.HouseListingsAssignment.Services.Constants;
using Funda.HouseListingsAssignment.Services.Contracts;
using Funda.HouseListingsAssignment.Services.Contracts.Configurations;
using Newtonsoft.Json;

namespace Funda.HouseListingsAssignment.Services
{
    public class RealEstateAgentsService : IRealEstateAgentsService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IServiceConfiguration _serviceConfiguration;

        public RealEstateAgentsService(IHttpClientService httpClientService, IServiceConfiguration serviceConfiguration)
        {
            _httpClientService = httpClientService;
            _serviceConfiguration = serviceConfiguration;
        }

        public async Task<IEnumerable<RealEstateAgent>> GetRealEstateAgentByMostSalesAsync(string type, string searchOptions, int numberOfItems)
        {
            int nextPage = 1;

            var realEstatesChunk = await GetRealEstatesAsync(type, searchOptions, nextPage, numberOfItems);
            List<RealEstate> realEstatesForSale = realEstatesChunk.Objects;

            while (realEstatesForSale.Count() < realEstatesChunk.TotaalAantalObjecten)
            {
                nextPage++;
                var estatesObject = await GetRealEstatesAsync(type, searchOptions, nextPage, numberOfItems);

                realEstatesForSale.AddRange(estatesObject.Objects);
            }

            var esteateAgents = realEstatesForSale.GroupBy(r => r.MakelaarId)
                                                    .OrderByDescending(r => r.Count())
                                                    .Select(r => new RealEstateAgent
                                                    {
                                                        MakelaarId = r.Key,
                                                        MakelaarNaam = r.Select(a => a.MakelaarNaam).FirstOrDefault(),
                                                        EstateCount = r.Count()
                                                    })
                                                    .Take(10)
                                                    .ToList();

            if (esteateAgents == null)
            {
                return null;
            }

            return esteateAgents;
        }

        private async Task<RootObject> GetRealEstatesAsync(string type, string searchOptions, int nextPage, int numberOfItems)
        {
            HttpClient client = _httpClientService.GetHttpClient();
            var apiKey = _serviceConfiguration.GetConfigSection(RealEstateConstants.FundaApiKey);

            var response = client.GetAsync(string.Format($"{client.BaseAddress.AbsoluteUri}/json/{apiKey}/?type={type}&zo={searchOptions}&page={nextPage}&pagesize={numberOfItems}")).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (JsonConvert.DeserializeObject(json) == null)
                {
                    return null;
                }

                var rootObject = JsonConvert.DeserializeObject<RootObject>(JsonConvert.DeserializeObject(json,
                                                   new JsonSerializerSettings()
                                                   {
                                                       TypeNameHandling = TypeNameHandling.Auto,
                                                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                   }).ToString());

                return rootObject;
            }

            return new RootObject
            {
                TotaalAantalObjecten = 0,
                Objects = new List<RealEstate>() { }
            };
        }
    }
}
