using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.ActiveIntegrations.Integrations
{
    public class GetActiveIntegrationsResponseApplicationActiveIntegrtion
    {
        [JsonProperty("media_source_name")]
        public string MediaSourceName { get; set; }

        [JsonProperty("is_integration_active")]
        public bool IsIntegrationActive { get; set; }

        [JsonProperty("is_cost_active")]
        public bool IsCostActive { get; set; }

        [JsonProperty("is_adrevenue_active")]
        public bool IsAdrevenueActive { get; set; }
    }
}
