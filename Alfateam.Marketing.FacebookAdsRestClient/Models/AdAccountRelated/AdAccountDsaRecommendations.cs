using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdAccountDsaRecommendations
    {
        [JsonProperty("recommendations")]
        public List<string> Recommendations { get; set; } = new List<string>();
    }
}
