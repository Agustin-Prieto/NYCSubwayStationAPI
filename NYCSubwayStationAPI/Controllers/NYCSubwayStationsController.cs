using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NYCSubwayStationAPI.Models;
using NYCSubwayStationAPI.Services.Interfaces;

namespace NYCSubwayStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NYCSubwayStationsController : ControllerBase
    {
        private readonly INYCSubwayStationsService _NYCSubwayStationsService;

        public NYCSubwayStationsController(INYCSubwayStationsService nYCSubwayStationsService)
        {
            _NYCSubwayStationsService = nYCSubwayStationsService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<SubwayStation>> GetNYCSubwayStations()
        {
            var stations = await _NYCSubwayStationsService.GetNYCSubwayStations();
            return stations;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/iDSubwayStationA/{iDSubwayStationA}/iDSubwayStationB/{iDSubwayStationB}")]
        public async Task<int> getDistanceBetweenStations([FromRoute]int iDSubwayStationA, [FromRoute] int iDSubwayStationB)
        {
            var distance = await _NYCSubwayStationsService.getDistanceBetween(iDSubwayStationA, iDSubwayStationB);

            return distance;
        }
    }
}
