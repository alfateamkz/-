using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountConnections
{
    public class ListPartnerConnectionsForAccountResponseConnection
    {
        [JsonProperty("integration_id")]
        public int IntegrationId { get; set; }

        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("integration_name")]
        public string IntegrationName { get; set; }
    }
}
