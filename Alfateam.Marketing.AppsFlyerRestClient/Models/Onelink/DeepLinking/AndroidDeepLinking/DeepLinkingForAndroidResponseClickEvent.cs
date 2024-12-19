using Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.Android;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking
{
    public class DeepLinkingForAndroidResponseClickEvent
    {
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("custom_params")]
        public object CustomParams { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("match_type")]
        public DeepLinkingForAndroidResponseClickEventMatchType MatchType { get; set; }


        [JsonProperty("media_source")]
        public string MediaSource { get; set; }

        [JsonProperty("campaign")]
        public string Campaign { get; set; }

        [JsonProperty("click_http_referrer")]
        public string ClickHttpReferrer { get; set; }

        [JsonProperty("af_sub1")]
        public string AfSub1 { get; set; }

        [JsonProperty("af_sub2")]
        public string AfSub2 { get; set; }

        [JsonProperty("af_sub3")]
        public string AfSub3 { get; set; }

        [JsonProperty("af_sub4")]
        public string AfSub4 { get; set; }

        [JsonProperty("af_sub5")]
        public string AfSub5 { get; set; }
    }
}
