using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdCampaignFrequencyControlSpecs
    {
        [JsonProperty("event")]
        public AdCampaignFrequencyControlSpecsEvent Event { get; set; }

        [JsonProperty("interval_days")]
        public uint IntervalDays { get; set; }

        [JsonProperty("max_frequency")]
        public uint MaxFrequency { get; set; }
    }
}
