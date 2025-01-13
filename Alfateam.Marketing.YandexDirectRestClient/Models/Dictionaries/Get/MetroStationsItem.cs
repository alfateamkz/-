using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class MetroStationsItem
    {
        [JsonProperty("GeoRegionId")]
        public long GeoRegionId { get; set; }

        [JsonProperty("MetroStationId")]
        public long MetroStationId { get; set; }

        [JsonProperty("MetroStationName")]
        public string MetroStationName { get; set; }
    }
}
