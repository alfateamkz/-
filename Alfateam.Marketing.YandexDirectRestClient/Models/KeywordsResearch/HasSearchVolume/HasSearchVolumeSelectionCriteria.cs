using Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.Deduplicate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.HasSearchVolume
{
    public class HasSearchVolumeSelectionCriteria
    {
        [JsonProperty("Keywords")]
        public List<string> Keywords { get; set; } = new List<string>();

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();
    }
}
