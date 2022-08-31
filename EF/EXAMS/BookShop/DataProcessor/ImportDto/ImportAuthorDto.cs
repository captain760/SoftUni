using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDto
    {
        [JsonProperty("FirstName")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        [Required]
        [MaxLength(12)]
        [RegularExpression(@"^(\d{3})-(\d{3})-(\d{4})$")]
        public string Phone { get; set; }

        [JsonProperty("Books")]
        public List<ImportBookIdDto> Books { get; set; }
    }

    public class ImportBookIdDto
    {
        [JsonProperty("Id")]
        public int? Id { get; set; }
    }
}
