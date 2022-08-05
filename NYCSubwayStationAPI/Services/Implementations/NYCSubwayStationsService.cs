using GeoCoordinatePortable;
using Microsoft.AspNetCore.Identity;
using NYCSubwayStationAPI.Data;
using NYCSubwayStationAPI.Models;
using NYCSubwayStationAPI.Services.Interfaces;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace NYCSubwayStationAPI.Services.Implementations
{
    public class NYCSubwayStationsService : INYCSubwayStationsService
    {
        private const string apiEndpoint = "https://data.cityofnewyork.us/resource/kk4q-3rt2.json";

        public NYCSubwayStationsService()
        {
        }

        public async Task<int> getDistanceBetween(int iDSubwayStationA, int iDSubwayStationB)
        {
            try
            {
                var stationA = await getNYCSubwayStationById(iDSubwayStationA);
                var stationB = await getNYCSubwayStationById(iDSubwayStationB);

                var sCoord = new GeoCoordinate((double)stationA.the_geom.coordinates[0], (double)stationA.the_geom.coordinates[1]);
                var eCoord = new GeoCoordinate((double)stationB.the_geom.coordinates[0], (double)stationB.the_geom.coordinates[1]);

                return (int)sCoord.GetDistanceTo(eCoord);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<List<SubwayStation>> GetNYCSubwayStations()
        {
            try
            {
                var responseString = "";
                var request = (HttpWebRequest)WebRequest.Create(apiEndpoint);
                request.Method = "GET";
                request.ContentType = "application/json";

                using (var response1 = request.GetResponse())
                {
                    using (var reader = new StreamReader(response1.GetResponseStream()))
                    {
                        responseString = reader.ReadToEnd();
                        List<SubwayStation>? x = JsonSerializer.Deserialize<List<SubwayStation>>(responseString);
                        return x;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<SubwayStation> getNYCSubwayStationById(int iD)
        {
            var result = this.GetNYCSubwayStations().Result.Find(x => x.objectid == iD);

            if (result != null)
            {
                return result;
            } else
            {
                throw new InvalidOperationException("Subway not found");
            }
        }
    }
}
