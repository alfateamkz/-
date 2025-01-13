using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class Phone
    {
        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("CityCode")]
        public string CityCode { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Extension")]
        public string Extension { get; set; }
    }
}
