using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class IronsourceNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("network_app_id")]
        public string NetworkAppId { get; set; }

        [JsonProperty("secret_key")]
        public string SecretKey { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
