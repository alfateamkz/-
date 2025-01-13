using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class GeoRegionsItem
    {
        [JsonProperty("GeoRegionId")]
        public long GeoRegionId { get; set; }

        [JsonProperty("GeoRegionName")]
        public string GeoRegionName { get; set; }

        [JsonProperty("GeoRegionType")]
        public string GeoRegionType { get; set; }

        [JsonProperty("ParentId")]
        public long ParentId { get; set; }
    }
}
