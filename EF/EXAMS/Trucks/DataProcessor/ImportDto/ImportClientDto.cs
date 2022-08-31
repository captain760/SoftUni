using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }
        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }
        [JsonProperty("Trucks")]
        public int[] Trucks { get; set; }
    }
}
