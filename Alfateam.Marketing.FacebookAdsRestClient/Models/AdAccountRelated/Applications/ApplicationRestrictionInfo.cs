using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Applications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Applications
{
    public class ApplicationRestrictionInfo
    {
        [JsonProperty("age")]
        public ApplicationRestrictionInfoAge Age { get; set; }

        [JsonProperty("age_distribution")]
        public string AgeDistribution { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("type")]
        public ApplicationRestrictionInfoType Type { get; set; }
    }
}
