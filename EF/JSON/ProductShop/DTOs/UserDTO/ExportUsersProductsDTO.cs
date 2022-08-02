using Newtonsoft.Json;
using ProductShop.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductShop.DTOs.UserDTO
{
    [JsonObject]
    public class ExportUsersProductsDTO
    {
        [JsonProperty("count")]
        public int ProductCount
            => SoldProducts.Any() ? SoldProducts.Count() : 0;
        [JsonProperty("products")]
        public ExportProductShortDTO[] SoldProducts { get; set; }   
    }
}
