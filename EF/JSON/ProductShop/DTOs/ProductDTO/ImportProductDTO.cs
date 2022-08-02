
using System.ComponentModel.DataAnnotations;

using ProductShop.Common;

using Newtonsoft.Json;

namespace ProductShop.DTOs.ProductDTO
{
    [JsonObject]
    public class ImportProductDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(GlobalConstants.MinLengthName)]
        public string Name { get; set; }
        [JsonProperty("Price")]
        [Required]
        public decimal Price { get; set; }
        [JsonProperty("SellerId")]
        [Required]
        public int SellerId { get; set; }
        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
