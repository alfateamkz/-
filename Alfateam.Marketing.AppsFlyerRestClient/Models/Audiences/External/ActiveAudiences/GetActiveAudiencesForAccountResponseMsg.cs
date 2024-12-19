using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.ActiveAudiences
{
    public class GetActiveAudiencesForAccountResponseMsg
    {
        [JsonProperty("results")]
        public List<GetActiveAudiencesForAccountResponseResult> Results { get; set; } = new List<GetActiveAudiencesForAccountResponseResult>();
    }
}
