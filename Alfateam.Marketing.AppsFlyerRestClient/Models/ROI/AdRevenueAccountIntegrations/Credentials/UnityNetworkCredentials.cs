using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class UnityNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("api_key")]
        public string APIKey { get; set; }

        [JsonProperty("source_ids")]
        public string SourceIds { get; set; }
    }
}
