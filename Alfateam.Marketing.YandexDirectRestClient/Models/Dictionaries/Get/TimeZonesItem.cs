using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class TimeZonesItem
    {
        [JsonProperty("TimeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("TimeZoneName")]
        public string TimeZoneName { get; set; }

        [JsonProperty("UtcOffset")]
        public int UtcOffset { get; set; }
    }
}
