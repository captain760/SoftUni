using Newtonsoft.Json;


namespace ProductShop.DTOs.CategoryProductDTO
{
    [JsonObject]
    public class ImportCategoryProductDTO
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
