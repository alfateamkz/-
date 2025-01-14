using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Links;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataAppLinkSpec
    {
        [JsonProperty("android")]
        public List<AndroidAppLink> Android { get; set; } = new List<AndroidAppLink>();

        [JsonProperty("ios")]
        public List<IosAppLink> iOS { get; set; } = new List<IosAppLink>();

        [JsonProperty("ipad")]
        public List<IosAppLink> iPad { get; set; } = new List<IosAppLink>();

        [JsonProperty("iphone")]
        public List<IosAppLink> iPhone { get; set; } = new List<IosAppLink>();
    }
}
