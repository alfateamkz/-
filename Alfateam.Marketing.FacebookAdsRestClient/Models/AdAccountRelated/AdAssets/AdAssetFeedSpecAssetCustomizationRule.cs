using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecAssetCustomizationRule
    {
        [JsonProperty("body_label")]
        public AdAssetFeedSpecAssetLabel BodyLabel { get; set; }

        [JsonProperty("call_to_action_label")]
        public AdAssetFeedSpecAssetLabel CallToActionLabel { get; set; }

        [JsonProperty("call_to_action_type_label")]
        public AdAssetFeedSpecAssetLabel CallToActionTypeLabel { get; set; }

        [JsonProperty("caption_label")]
        public AdAssetFeedSpecAssetLabel CaptionLabel { get; set; }

        [JsonProperty("carousel_label")]
        public AdAssetFeedSpecAssetLabel CarouselLabel { get; set; }

        [JsonProperty("customization_spec")]
        public AdAssetCustomizationRuleCustomizationSpec CustomizationSpec { get; set; }

        [JsonProperty("description_label")]
        public AdAssetFeedSpecAssetLabel DescriptionLabel { get; set; }

        [JsonProperty("image_label")]
        public AdAssetFeedSpecAssetLabel ImageLabel { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("link_url_label")]
        public AdAssetFeedSpecAssetLabel LinkURLLabel { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("title_label")]
        public AdAssetFeedSpecAssetLabel TitleLabel { get; set; }

        [JsonProperty("video_label")]
        public AdAssetFeedSpecAssetLabel VideoLabel { get; set; }
    }
}
