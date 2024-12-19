using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.GetSplit
{
    public class GetSplitPercentagesForAudienceResponse
    {
        [JsonProperty("message")]
        public GetSplitPercentagesForAudienceResponseMessage Message { get; set; }
    }
}
