using Newtonsoft.Json;
using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportDepartmentDto
    {
        public ImportDepartmentDto()
        {
            this.Cells = new List<ImportCellDto>();
        }
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public List<ImportCellDto> Cells { get; set; }
    }
}
