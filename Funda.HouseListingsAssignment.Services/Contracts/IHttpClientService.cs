using System.Net.Http;

namespace Funda.HouseListingsAssignment.Services.Contracts
{
    public interface IHttpClientService
    {
        HttpClient GetHttpClient();
    }
}
