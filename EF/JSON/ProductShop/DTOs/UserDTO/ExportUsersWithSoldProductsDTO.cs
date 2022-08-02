using Newtonsoft.Json;
using ProductShop.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.UserDTO
{
    [JsonObject]
    public class ExportUsersWithSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportUserSoldProductsDTO[] SoldProducts { get; set; }
    }
}
