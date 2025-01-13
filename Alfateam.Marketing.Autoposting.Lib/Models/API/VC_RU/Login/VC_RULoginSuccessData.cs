using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Login
{
    public class VC_RULoginSuccessData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("accessExpTimestamp")]
        public int AccessExpTimestamp { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("refreshExpTimestamp")]
        public int RefreshExpTimestamp { get; set; }
    }
}
