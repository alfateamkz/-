using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.GetGeoRegions
{
    public class GeoRegionsGetItem
    {
        [JsonProperty("GeoRegionId")]
        public long GeoRegionId { get; set; }

        [JsonProperty("GeoRegionName")]
        public string GeoRegionName { get; set; }

        [JsonProperty("ParentGeoRegionNames")]
        public ArrayOfString ParentGeoRegionNames { get; set; }
    }
}
