using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ListPartner
{
    public class ListPartnerConnectionsForAudienceResponseMessage
    {
        [JsonProperty("connections")]
        public List<ListPartnerConnectionsForAudienceResponseConnection> Connections { get; set; } = new List<ListPartnerConnectionsForAudienceResponseConnection>();
    }
}
