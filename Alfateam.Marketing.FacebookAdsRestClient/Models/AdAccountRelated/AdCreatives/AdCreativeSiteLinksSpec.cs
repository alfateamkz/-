using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeSiteLinksSpec
    {
        [JsonProperty("site_link_image_hash")]
        public string SiteLinkImageHash { get; set; }

        [JsonProperty("site_link_image_url")]
        public string SiteLinkImageURL { get; set; }

        [JsonProperty("site_link_title")]
        public string SiteLinkTitle { get; set; }

        [JsonProperty("site_link_url")]
        public string SiteLinkURL { get; set; }
    }
}
