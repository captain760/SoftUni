using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerWithMailDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }
        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression(@"^The [A-Z][a-z]+$")]
        public string Nickname { get; set; }
        [JsonProperty("Age")]
        [Range(18,65)]
        public int Age { get; set; }
        [JsonProperty("IncarcerationDate")]
        [Required]
        public string IncarcerationDate { get; set; }
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }
        [JsonProperty("Bail")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }
        [JsonProperty("CellId")]
        public int? CellId { get; set; }
        [JsonProperty("Mails")]
        public List<ImportPrisonerMail> Mails { get; set; }
    }
}
