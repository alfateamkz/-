using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations
{
    public class AdRevenueAccountIntegration
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("network")]
        public AdRevenueAccountIntegrationNetworkType Network { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("credentials")]
        public AdRevenueAccountIntegrationNetworkCredentials credentials { get; set; }

        [JsonProperty("products")]
        public List<AdRevenueAccountIntegrationProduct> Products { get; set; } = new List<AdRevenueAccountIntegrationProduct>();
    }
}
