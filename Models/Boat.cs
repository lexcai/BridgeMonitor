using System;
using Newtonsoft.Json;

namespace BridgeMonitor.Models
{
    public class Boat
    {
        [JsonProperty("boat_name")]
        public string _BoatName { get; set; }
        [JsonProperty("closing_type")]
        public string _ClosingType { get; set; }
        [JsonProperty("closing_date")]
        public DateTime _ClosingDate { get; set; }
        [JsonProperty("reopening_date")]
        public DateTime _ReopeningDate { get; set; }

    }
}
