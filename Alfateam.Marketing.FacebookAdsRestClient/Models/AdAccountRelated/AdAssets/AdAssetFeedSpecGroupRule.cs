using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecGroupRule
    {
        [JsonProperty("body_label")]
        public AdAssetFeedSpecAssetLabel BodyLabel { get; set; }

        [JsonProperty("caption_label")]
        public AdAssetFeedSpecAssetLabel CaptionLabel { get; set; }

        [JsonProperty("description_label")]
        public AdAssetFeedSpecAssetLabel DescriptionLabel { get; set; }

        [JsonProperty("image_label")]
        public AdAssetFeedSpecAssetLabel ImageLabel { get; set; }

        [JsonProperty("link_url_label")]
        public AdAssetFeedSpecAssetLabel LinkURLLabel { get; set; }

        [JsonProperty("title_label")]
        public AdAssetFeedSpecAssetLabel TitleLabel { get; set; }

        [JsonProperty("video_label")]
        public AdAssetFeedSpecAssetLabel VideoLabel { get; set; }
    }
}
