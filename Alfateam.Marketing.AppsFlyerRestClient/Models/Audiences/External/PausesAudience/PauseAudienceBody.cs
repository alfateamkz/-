using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.PausesAudience
{
    public class PauseAudienceBody
    {
        [JsonProperty("audience_ids")]
        public List<string> AudienceIds { get; set; } = new List<string>();
    }
}
