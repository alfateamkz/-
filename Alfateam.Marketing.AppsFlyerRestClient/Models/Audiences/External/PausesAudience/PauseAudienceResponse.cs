using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.PausesAudience
{
    public class PauseAudienceResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
