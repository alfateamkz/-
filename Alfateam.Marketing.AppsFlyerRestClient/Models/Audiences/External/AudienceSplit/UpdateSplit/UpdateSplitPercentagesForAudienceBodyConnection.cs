using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.UpdateSplit
{
    public class UpdateSplitPercentagesForAudienceBodyConnection
    {
        [JsonProperty("integration_id")]
        public int IntegrationId { get; set; }
    }
}
