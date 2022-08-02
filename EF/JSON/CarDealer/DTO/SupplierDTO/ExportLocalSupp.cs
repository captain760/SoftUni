using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.DTO.SupplierDTO
{
    [JsonObject]
    public class ExportLocalSupp
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PartsCount")]
        public int PartsCount { get; set; }
    }
}
