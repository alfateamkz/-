using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.ClickEngagementPost;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.ImpressionEngagement.ImpressionEngagementPost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ImpressionEngagement.ImpressionEngagementPost
{
    public class ImpressionEngagementPostBody
    {
        [JsonProperty("af_media_source")]
        public string AfMediaSource { get; set; }

        [JsonProperty("af_campaign_id")]
        public string AfCampaignId { get; set; }

        [JsonProperty("af_request_id")]
        public string AfRequestId { get; set; }

        [JsonProperty("af_campaign")]
        public string AfCampaign { get; set; }

        [JsonProperty("af_adset_id")]
        public string AfAdsetId { get; set; }

        [JsonProperty("af_adset")]
        public string AfAdset { get; set; }

        [JsonProperty("af_ad_id")]
        public string AfAdId { get; set; }

        [JsonProperty("af_ad")]
        public string AfAd { get; set; }

        [JsonProperty("af_campaign_type")]
        public ImpressionEngagementPostAfCampaignType AfCampaignType { get; set; }

        [JsonProperty("af_prt")]
        public string AfPrt { get; set; }

        [JsonProperty("af_siteid")]
        public string AfSiteid { get; set; }

        [JsonProperty("af_sub_siteid")]
        public string AfSubSiteid { get; set; }

        [JsonProperty("af_click_id")]
        public string AfClickId { get; set; }

        [JsonProperty("af_lookback_window")]
        public string AfLookbackWindow { get; set; }

        [JsonProperty("af_ad_placement")]
        public string AfAdPlacement { get; set; }

        [JsonProperty("af_ad_type")]
        public ImpressionEngagementPostAfAdType AfAdType { get; set; }

        [JsonProperty("af_channel")]
        public string AfChannel { get; set; }

        [JsonProperty("af_custom1")]
        public string AfCustom1 { get; set; }

        [JsonProperty("af_custom2")]
        public string AfCustom2 { get; set; }

        [JsonProperty("af_custom3")]
        public string AfCustom3 { get; set; }

        [JsonProperty("af_custom4")]
        public string AfCustom4 { get; set; }

        [JsonProperty("af_custom5")]
        public string AfCustom5 { get; set; }

        [JsonProperty("af_model")]
        public string AfModel { get; set; }

        [JsonProperty("af_os_version")]
        public string AfOSVersion { get; set; }

        [JsonProperty("af_device_id_type")]
        public ImpressionEngagementPostAfDeviceIdType AfDeviceIdType { get; set; }

        [JsonProperty("af_device_id_value")]
        public string AfDeviceIdValue { get; set; }

        [JsonProperty("af_ip")]
        public string AfIP { get; set; }

        [JsonProperty("af_user_agent")]
        public string AfUserAgent { get; set; }
    }
}
