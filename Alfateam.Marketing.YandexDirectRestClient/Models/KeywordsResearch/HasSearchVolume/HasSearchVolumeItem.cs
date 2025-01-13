using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.HasSearchVolume
{
    public class HasSearchVolumeItem
    {
        [JsonProperty("Keyword")]
        public string Keyword { get; set; }

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();

        [JsonProperty("AllDevices")]
        public YesNoEnum AllDevices { get; set; }

        [JsonProperty("MobilePhones")]
        public YesNoEnum MobilePhones { get; set; }

        [JsonProperty("Tablets")]
        public YesNoEnum Tablets { get; set; }

        [JsonProperty("Desktops")]
        public YesNoEnum Desktops { get; set; }
    }
}
