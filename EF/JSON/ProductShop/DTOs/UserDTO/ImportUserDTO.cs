using Newtonsoft.Json;
using ProductShop.Common;
using System.ComponentModel.DataAnnotations;


namespace ProductShop.DTOs.UserDTO
{
    [JsonObject]
    public class ImportUserDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        [Required]
        [MinLength(GlobalConstants.MinLengthName)]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }

    }
}
