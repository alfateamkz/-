using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.ActiveIntegrations.Integrations
{
    public class GetActiveIntegrationsResponseApplication
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
