using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject("Countries")]
    public class ImportGunCountryDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
