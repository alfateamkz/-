using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.GetSplit
{
    public class GetSplitPercentagesForAudienceResponseMessage
    {
        [JsonProperty("connections")]
        public List<GetSplitPercentagesForAudienceResponseConnection> Connections { get; set; } = new List<GetSplitPercentagesForAudienceResponseConnection>();
    }
}
