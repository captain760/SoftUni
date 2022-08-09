using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCellDto
    {
        [JsonProperty("CellNumber")]
        [Range(1,1000)]
        public int CellNumber { get; set; }
        [JsonProperty("HasWindow")]
        public bool HasWindow { get; set; }
    }
}
