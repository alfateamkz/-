using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANAggregatedPostbackByArrivalDate.Postbacks
{
    public class GetAggregatedPostbacksQueryParams
    {
        [JsonProperty("start_date")]
        public DateOnly StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateOnly EndDate { get; set; }

        [JsonProperty("ad_network_name")]
        public string AdNetworkName { get; set; }

        [JsonProperty("geo")]
        public string Geo { get; set; }

        [JsonProperty("skad_redownload")]
        public bool SKAdRedownload { get; set; }

        [JsonProperty("skad_source_app_id")]
        public string SKAdSourceAppId { get; set; }

        [JsonProperty("ad_network_campaign_id")]
        public string AdNetworkCampaignId { get; set; }

        [JsonProperty("modeled_conversion_values")]
        public bool ModeledConversionValues { get; set; }
    }
}
