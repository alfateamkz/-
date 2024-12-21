using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class ToponNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("network_app_id")]
        public string NetworkAppId { get; set; }

        [JsonProperty("publisher_key")]
        public string PublisherKey { get; set; }
    }
}
