using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.UpdateApp
{
    public class UpdateAppBody
    {
        [JsonProperty("enableProbabilisticViewThroughAttribution")]
        public bool EnableProbabilisticViewThroughAttribution { get; set; }

        [JsonProperty("enableIpMasking")]
        public bool EnableIPMasking { get; set; }

        [JsonProperty("minTimeBetweenSessions")]
        public int MinTimeBetweenSessions { get; set; }

        [JsonProperty("reAttributionWindow")]
        public int ReAttributionWindow { get; set; }

        [JsonProperty("reEngagementAttribution")]
        public UpdateAppBodyReEngagementAttribution ReEngagementAttribution { get; set; }

        [JsonProperty("enableSeoAppAttribution")]
        public bool EnableSEOAppAttribution { get; set; }

        [JsonProperty("enableAggregatedAdvancedPrivacy")]
        public bool EnableAggregatedAdvancedPrivacy { get; set; }

        [JsonProperty("enableReinstallDetection")]
        public bool EnableReinstallDetection { get; set; }
    }
}
