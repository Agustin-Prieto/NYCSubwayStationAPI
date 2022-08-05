using System.Text.Json.Serialization;

namespace NYCSubwayStationAPI.Models
{
    public class SubwayStation
    {
        public string url { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int objectid { get; set; }
        public string name { get; set; }
        public string line { get; set; }
        public string notes { get; set; }
        public Coords the_geom { get; set; }
    }
}
