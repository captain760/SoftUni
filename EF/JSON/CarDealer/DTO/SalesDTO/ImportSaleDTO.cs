using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.SalesDTO
{
    [JsonObject]
    internal class ImportSaleDTO
    {
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}
