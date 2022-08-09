using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportPrisonerByCellsDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string FullName { get; set; }
        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }
        [JsonProperty("Officers")]
        public ExportOfficerDepDto[] Officers { get; set; }
    }
}
