using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class VideoBoostEligibilityInfo
    {
        [JsonProperty("boost_ineligible_reason")]
        public string BoostIneligibleReason { get; set; }

        [JsonProperty("eligible_to_boost")]
        public bool EligibleToBoost { get; set; }
    }
}
