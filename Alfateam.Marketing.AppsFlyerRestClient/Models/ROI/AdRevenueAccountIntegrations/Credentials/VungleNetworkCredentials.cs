using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class VungleNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
    }
}
