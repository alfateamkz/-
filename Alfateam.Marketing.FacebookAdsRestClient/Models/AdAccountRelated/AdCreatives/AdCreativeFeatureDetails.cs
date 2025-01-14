using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeFeatureDetails
    {
        [JsonProperty("customizations")]
        public AdCreativeFeatureCustomizations Customizations { get; set; }

        [JsonProperty("enroll_status")]
        public AdCreativeFeatureDetailsEnrollStatus EnrollStatus { get; set; }
    }
}
