using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ListPartner
{
    public class ListPartnerConnectionsForAudienceResponse
    {
        [JsonProperty("message")]
        public ListPartnerConnectionsForAudienceResponseMessage Message { get; set; }
    }
}
