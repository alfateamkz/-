using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.ActiveIntegrations.Integrations
{
    public class GetActiveIntegrationsResponse
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("applications")]
        public List<GetActiveIntegrationsResponseApplication> Applications { get; set; } = new List<GetActiveIntegrationsResponseApplication>();
    }
}
