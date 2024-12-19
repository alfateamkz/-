using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ConnectAudience
{
    public class ConnectAudienceToExistingPartnersResponse
    {
        [JsonProperty("message")]
        public ConnectAudienceToExistingPartnersResponseMessage Message { get; set; }
    }
}
