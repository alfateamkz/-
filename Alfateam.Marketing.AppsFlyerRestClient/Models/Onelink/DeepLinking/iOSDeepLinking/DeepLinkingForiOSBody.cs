using Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.iOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.iOSDeepLinking
{
    public class DeepLinkingForiOSBody
    {
        [JsonProperty("idfv")]
        public DeepLinkingForiOSBodyIdfv Idfv { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("att_status")]
        public DeepLinkingForiOSBodyAttStatus AttStatus { get; set; }

        [JsonProperty("is_first")]
        public bool IsFirst { get; set; }

        [JsonProperty("open_referrer")]
        public string OpenReferrer { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("os")]
        public string OS { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }


        [JsonProperty("idfa")]
        public DeepLinkingForiOSBodyIdfa Idfa { get; set; }

        [JsonProperty("sharing_filter")]
        public string SharingFilter { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
