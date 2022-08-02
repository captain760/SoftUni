using System.ComponentModel.DataAnnotations;

using ProductShop.Common;

using Newtonsoft.Json;


namespace ProductShop.DTOs.CategoryDTO
{
    [JsonObject]
    public class ImportCategoryDTO
    {
        [JsonProperty("name")]
        [MinLength(GlobalConstants.MinLengthName)]
        [MaxLength(GlobalConstants.MaxLengthName)]
        public string Name { get; set; }
    }
}
