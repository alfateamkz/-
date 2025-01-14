using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeAdDisclaimer
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public AdCreativeAdDisclaimerTitle Title { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
