using System.Collections.Generic;
using System.Threading.Tasks;
using Funda.HouseListingsAssignment.Models;

namespace Funda.HouseListingsAssignment.Services.Contracts
{
    public interface IRealEstateAgentsService
    {
        Task<IEnumerable<RealEstateAgent>> GetRealEstateAgentByMostSalesAsync(string type, string searchOptions, int numberOfItems);
    }
}