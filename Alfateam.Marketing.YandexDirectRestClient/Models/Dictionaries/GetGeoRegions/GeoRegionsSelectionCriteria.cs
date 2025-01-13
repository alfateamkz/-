using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.GetGeoRegions
{
    public class GeoRegionsSelectionCriteria
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();

        [JsonProperty("ExactNames")]
        public List<string> ExactNames { get; set; } = new List<string>();
    }
}
