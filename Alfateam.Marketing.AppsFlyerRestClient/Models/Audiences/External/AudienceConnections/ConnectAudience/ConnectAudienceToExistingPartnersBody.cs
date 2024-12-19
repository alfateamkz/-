using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ConnectAudience
{
    public class ConnectAudienceToExistingPartnersBody
    {
        [JsonProperty("connections")]
        public List<ConnectAudienceToExistingPartnersBodyConnection> Connections { get; set; } = new List<ConnectAudienceToExistingPartnersBodyConnection>();
    }
}
