using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecImage
    {
        [JsonProperty("adlabels")]
        public List<AdAssetFeedSpecAssetLabel> AdLabels { get; set; } = new List<AdAssetFeedSpecAssetLabel>();

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("url_tags")]
        public string URLTTags { get; set; }
    }
}
