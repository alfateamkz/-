using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeWebData
    {
        [JsonProperty("should_fallback")]
        public string ShouldFallback { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
