using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.UpdateSplit
{
    public class UpdateSplitPercentagesForAudienceResponse
    {
        [JsonProperty("message")]
        public UpdateSplitPercentagesForAudienceResponseMessage Message { get; set; }
    }
}
