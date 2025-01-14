using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class ReachFrequencySpec
    {
        [JsonProperty("countries")]
        public List<string> Countries { get; set; } = new List<string>();

        [JsonProperty("min_campaign_duration")]
        public Dictionary<string,double> MinCampaignDuration { get; set; } = new Dictionary<string, double>();

        [JsonProperty("max_campaign_duration")]
        public Dictionary<string, double> MaxCampaignDuration { get; set; } = new Dictionary<string, double>();

        [JsonProperty("max_days_to_finish")]
        public Dictionary<string, double> MaxDaysToFinish { get; set; } = new Dictionary<string, double>();

        [JsonProperty("min_reach_limits")]
        public Dictionary<string, double> MinReachLimits { get; set; } = new Dictionary<string, double>();
    }
}
