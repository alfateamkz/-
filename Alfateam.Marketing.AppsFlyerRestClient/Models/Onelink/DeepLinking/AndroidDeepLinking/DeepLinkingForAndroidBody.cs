using Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking
{
    public class DeepLinkingForAndroidBody
    {
        [JsonProperty("referrers")]
        public List<DeepLinkingForAndroidBodyReferrer> Referrers { get; set; } = new List<DeepLinkingForAndroidBodyReferrer>();

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("is_first")]
        public bool IsFirst { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("os")]
        public string OS { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("oaid")]
        public DeepLinkingForAndroidBodyOaid Oaid { get; set; }

        [JsonProperty("type")]
        public DateTime Type { get; set; }

        [JsonProperty("gaid")]
        public DeepLinkingForAndroidBodyGaid Gaid { get; set; }

        [JsonProperty("sharing_filter")]
        public string SharingFilter { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
