using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.CategoryDTO
{
    
    [JsonObject]
    public class ExportCategoryByProductCountDTO
    {
        
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("averagePrice")]
        
        public string AveragePrice { get ;  set; }

        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
