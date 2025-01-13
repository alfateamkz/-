using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdBidAdjustments
    {
        [JsonProperty("age_range")]
        public Dictionary<string, float> AgeRange { get; set; } = new Dictionary<string, float>();

        [JsonProperty("page_types")]
        public PageTypeAdjustments PageTypes { get; set; }

        [JsonProperty("user_groups")]
        public string UserGroups { get; set; }
    }
}
