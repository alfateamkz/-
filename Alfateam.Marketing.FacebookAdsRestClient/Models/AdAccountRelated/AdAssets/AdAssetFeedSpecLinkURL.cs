using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecLinkURL
    {
        [JsonProperty("adlabels")]
        public List<AdAssetFeedSpecAssetLabel> AdLabels { get; set; } = new List<AdAssetFeedSpecAssetLabel>();

        [JsonProperty("carousel_see_more_url")]
        public string CarouselSeeMoreURL { get; set; }

        [JsonProperty("deeplink_url")]
        public string DeeplinkURL { get; set; }

        [JsonProperty("display_url")]
        public string DisplayURL { get; set; }

        [JsonProperty("object_store_urls")]
        public List<string> ObjectStoreURLs { get; set; } = new List<string>();

        [JsonProperty("url_tags")]
        public string URLTags { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteURL { get; set; }
    }
}
