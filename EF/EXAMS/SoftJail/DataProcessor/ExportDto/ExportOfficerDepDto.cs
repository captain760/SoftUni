using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportOfficerDepDto
    {
        [JsonProperty("OfficerName")]
        public string FullName { get; set; }
        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}
