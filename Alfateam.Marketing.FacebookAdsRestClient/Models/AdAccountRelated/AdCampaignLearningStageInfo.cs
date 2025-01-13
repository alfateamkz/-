using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdCampaignLearningStageInfo
    {
        [JsonProperty("attribution_windows")]
        public List<AdCampaignLearningStageInfoAttibutionWindow> AttributionWindows { get; set; } = new List<AdCampaignLearningStageInfoAttibutionWindow>();

        [JsonProperty("conversions")]
        public uint Conversions { get; set; }

        [JsonProperty("last_sig_edit_ts")]
        public int LastSigEditTS { get; set; }

        [JsonProperty("status")]
        public AdCampaignLearningStageInfoStatus Status { get; set; }
    }
}
