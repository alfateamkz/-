using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.PreloadMeasurement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadC2SMeasurement.DownloadEvents
{
    public class PreloadC2SDownloadEventBody
    {
        [JsonProperty("af_media_source")]
        public string AFMediaSource { get; set; }

        [JsonProperty("af_request_id")]
        public string AFRequestId { get; set; }

        [JsonProperty("af_ip")]
        public string AFIP { get; set; }

        [JsonProperty("af_engagement_type")]
        public PreloadMeasurementAFEngagementType AFEngagementType { get; set; }

        [JsonProperty("af_campaign")]
        public string AFCampaign { get; set; }

        [JsonProperty("af_campaign_id")]
        public string AFCampaignId { get; set; }

        [JsonProperty("af_adset")]
        public string AFAdset { get; set; }

        [JsonProperty("af_adset_id")]
        public string AFAdsetId { get; set; }

        [JsonProperty("af_ad")]
        public string AFAd { get; set; }

        [JsonProperty("af_ad_id")]
        public string AFAdId { get; set; }

        [JsonProperty("af_prt")]
        public string AFPrt { get; set; }

        [JsonProperty("af_click_id")]
        public string AFClickId { get; set; }

        [JsonProperty("af_lookback_window")]
        public string AFLookbackWindow { get; set; }

        [JsonProperty("af_ad_type")]
        public PreloadMeasurementAFAdType AFAdType { get; set; }

        [JsonProperty("af_channel")]
        public string AFChannel { get; set; }

        [JsonProperty("af_cost_model")]
        public PreloadMeasurementAFCostModel AFCostModel { get; set; }

        [JsonProperty("af_cost_value")]
        public string AFCostValue { get; set; }

        [JsonProperty("af_cost_currency")]
        public string AFCostCurrency { get; set; }

        [JsonProperty("af_custom1")]
        public string AFCustom1 { get; set; }

        [JsonProperty("af_custom2")]
        public string AFCustom2 { get; set; }

        [JsonProperty("af_custom3")]
        public string AFCustom3 { get; set; }

        [JsonProperty("af_custom4")]
        public string AFCustom4 { get; set; }

        [JsonProperty("af_custom5")]
        public string AFCustom5 { get; set; }

        [JsonProperty("af_model")]
        public string AFModel { get; set; }

        [JsonProperty("af_os_version")]
        public string AFOSVersion { get; set; }

        [JsonProperty("af_siteid")]
        public string AFSiteid { get; set; }

        [JsonProperty("af_sub_siteid")]
        public string AFSubSiteid { get; set; }

        [JsonProperty("af_user_agent")]
        public string AFUserAgent { get; set; }

        [JsonProperty("af_device_id_type")]
        public PreloadMeasurementAFDeviceIdType AFDeviceIdType { get; set; }

        [JsonProperty("af_device_id_value")]
        public string AFDeviceIdValue { get; set; }

        [JsonProperty("af_device_id_encoding")]
        public PreloadMeasurementAFDeviceIdEncoding AFDeviceIdEncoding { get; set; }
    }
}
