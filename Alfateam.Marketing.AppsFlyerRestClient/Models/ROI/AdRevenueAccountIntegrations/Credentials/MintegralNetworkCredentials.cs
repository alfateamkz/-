using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class MintegralNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("network_app_id")]
        public string NetworkAppId { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("skey")]
        public string SKey { get; set; }
    }
}
