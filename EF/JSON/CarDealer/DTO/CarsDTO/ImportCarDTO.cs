using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.CarsDTO
{
    [JsonObject]
    public class ImportCarDTO
    {
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }
        [JsonProperty("partsId")]
        public virtual IEnumerable<int> PartsId { get; set; }

    }
}
