using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdAccountReachEstimate
    {
        [JsonProperty("estimate_ready")]
        public bool EstimateReady { get; set; }

        [JsonProperty("users_lower_bound")]
        public int UsersLowerBound { get; set; }

        [JsonProperty("users_upper_bound")]
        public int UsersUpperBound { get; set; }
    }
}
