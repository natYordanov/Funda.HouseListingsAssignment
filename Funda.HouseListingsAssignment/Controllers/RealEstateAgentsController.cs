using System.Collections.Generic;
using System.Threading.Tasks;
using Funda.HouseListingsAssignment.Models;
using Funda.HouseListingsAssignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Funda.HouseListingsAssignment.Controllers
{
    [ApiController]
    public class RealEstateAgentsController : ControllerBase
    {
        private readonly ILogger<RealEstateAgentsController> _logger;
        private readonly IRealEstateAgentsService _realEstateAgentsService;

        public RealEstateAgentsController(ILogger<RealEstateAgentsController> logger,
            IRealEstateAgentsService realEstateAgentsService
            )
        {
            _logger = logger;
            _realEstateAgentsService = realEstateAgentsService;
        }

        [HttpGet]
        [Route("api/getagents/{search}/{type}")]
        [Route("api/getagents/{search}/{additionalSearch}/{type}")]
        public async Task<IEnumerable<RealEstateAgent>> GetRealEstateAgentsAsync([FromRoute] string search, string additionalSearch, string type)
        {
            string searchOptions = additionalSearch != null ? $"/{search}/{additionalSearch}/" : $"/{search}/";

            var realEstateAgents = await _realEstateAgentsService.GetRealEstateAgentByMostSalesAsync(type, searchOptions, 25);

            return realEstateAgents;
        }
    }
}
