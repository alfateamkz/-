using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Links
{
    public class WebAppLink
    {
        [JsonProperty("should_fallback")]
        public bool ShouldFallback { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
