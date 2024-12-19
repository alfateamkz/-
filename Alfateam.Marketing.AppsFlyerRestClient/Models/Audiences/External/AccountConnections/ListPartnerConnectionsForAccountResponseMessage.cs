using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountConnections
{
    public class ListPartnerConnectionsForAccountResponseMessage
    {
        [JsonProperty("connections")]
        public List<ListPartnerConnectionsForAccountResponseConnection> Connections { get; set; } = new List<ListPartnerConnectionsForAccountResponseConnection>();
    }
}
