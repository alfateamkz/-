using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Ads
{
    public class AdgroupReviewFeedback
    {
        [JsonProperty("global")]
        public Dictionary<string, string> Global { get; set; } = new Dictionary<string, string>();

        [JsonProperty("placement_specific")]
        public AdgroupPlacementSpecificReviewFeedback PlacementSpecific { get; set; }
    }
}
