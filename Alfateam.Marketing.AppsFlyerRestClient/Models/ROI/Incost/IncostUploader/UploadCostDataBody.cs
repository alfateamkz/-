using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostUploader
{
    public class UploadCostDataBody
    {
        [JsonProperty("date")]
        public DateOnly Date { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("media_source")]
        public string MediaSource { get; set; }

        [JsonProperty("af_prt")]
        public string AfPrt { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        [JsonProperty("adset_id")]
        public string AdsetId { get; set; }

        [JsonProperty("adset_name")]
        public string AdsetName { get; set; }

        [JsonProperty("ad_id")]
        public string AdId { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("ad_name")]
        public string AdName { get; set; }

        [JsonProperty("geo")]
        public string Geo { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("spend")]
        public int Spend { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}
