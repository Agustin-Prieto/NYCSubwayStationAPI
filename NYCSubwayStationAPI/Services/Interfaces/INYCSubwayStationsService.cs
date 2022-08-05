using NYCSubwayStationAPI.Models;
using System.Security.Claims;

namespace NYCSubwayStationAPI.Services.Interfaces
{
    public interface INYCSubwayStationsService
    {
        public Task<List<SubwayStation>> GetNYCSubwayStations();
        public Task<int> getDistanceBetween(int iDSubwayStationA, int iDSubwayStationB);
    }
}
