﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; }

        [JsonProperty("Developer")]
        [Required]        
        public string Developer { get; set; }

        [JsonProperty("Genre")]
        [Required]
        public string Genre { get; set; }

        [JsonProperty("Tags")]
        [Required]
        public virtual ICollection<string> Tags { get; set; }
    }
}
