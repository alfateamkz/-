using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomAudiences;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.CustomAudiences
{
    public class CustomAudienceDataSource
    {
        [JsonProperty("creation_params")]
        public string CreationParams { get; set; }

        [JsonProperty("sub_type")]
        public CustomAudienceSubtype SubType { get; set; }

        [JsonProperty("type")]
        public CustomAudienceType Type { get; set; }
    }
}
