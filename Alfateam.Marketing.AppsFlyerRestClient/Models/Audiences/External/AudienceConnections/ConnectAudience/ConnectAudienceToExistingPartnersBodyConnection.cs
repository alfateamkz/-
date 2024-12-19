using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ConnectAudience
{
    public class ConnectAudienceToExistingPartnersBodyConnection
    {
        [JsonProperty("integration_id")]
        public int IntegrationId { get; set; }


        [JsonProperty("split_ratio")]
        public Dictionary<string, string> SplitRatio { get; set; } = new Dictionary<string, string>();
    }
}
