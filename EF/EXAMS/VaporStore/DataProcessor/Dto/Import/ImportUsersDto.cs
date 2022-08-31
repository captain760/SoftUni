using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDto
    {
        [JsonProperty("Username")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }
        [JsonProperty("FullName")]
        [Required]
        [RegularExpression(@"^([A-Z][a-z]+) ([A-Z][a-z]+)$")]
        public string FullName { get; set; }
        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [JsonProperty("Age")]
        [Required]
        [Range(3, 103)]
        public int Age { get; set; }
        [JsonProperty("Cards")]
        public virtual ICollection<CardDto> Cards { get; set; }
    }

    public class CardDto
    {
        [JsonProperty("Number")]
        [Required]
        [RegularExpression(@"^(\d{4}) (\d{4}) (\d{4}) (\d{4})$")]
        [MaxLength(19)]
        public string Number { get; set; }
        [JsonProperty("CVC")]
        [Required]
        [RegularExpression(@"^(\d{3})$")]
        [MaxLength(3)]
        public string Cvc { get; set; }
        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }
    }
}
