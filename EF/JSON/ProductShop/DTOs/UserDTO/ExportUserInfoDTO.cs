using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.UserDTO
{
    [JsonObject]
    public class ExportUserInfoDTO
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }
        [JsonProperty("users")]
        public ExportUserFullDTO[] UsersDisplayed { get; set; }
    }
}
