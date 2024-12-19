using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience
{
    public class CreateNewImportedAudienceBodyConnection
    {
        [JsonProperty("integration_id")]
        public int IntegrationId { get; set; }

        [JsonProperty("split_ratio")]
        public int SplitRatio { get; set; }
    }
}
