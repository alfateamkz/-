using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecVideo
    {
        [JsonProperty("adlabels")]
        public List<AdAssetFeedSpecAssetLabel> AdLabels { get; set; } = new List<AdAssetFeedSpecAssetLabel>();

        [JsonProperty("caption_ids")]
        public List<long> CaptionIds { get; set; } = new List<long>();

        [JsonProperty("thumbnail_hash")]
        public string ThumbnailHash { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailURL { get; set; }

        [JsonProperty("url_tags")]
        public string URLTags { get; set; }

        [JsonProperty("video_id")]
        public string VideoId { get; set; }
    }
}
