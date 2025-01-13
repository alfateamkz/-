using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.GetGeoRegions
{
    public class DictionariesGetGeoRegionsResultBody
    {
        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }

        [JsonProperty("GeoRegions")]
        public List<GeoRegionsGetItem> GeoRegions { get; set; } = new List<GeoRegionsGetItem>();
    }
}
