using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.CheckDictionaries
{
    public class ChangesCheckDictionariesResultBody
    {
        [JsonProperty("TimeZonesChanged")]
        public YesNoEnum TimeZonesChanged { get; set; }

        [JsonProperty("RegionsChanged")]
        public YesNoEnum RegionsChanged { get; set; }

        [JsonProperty("InterestsChanged")]
        public YesNoEnum InterestsChanged { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
