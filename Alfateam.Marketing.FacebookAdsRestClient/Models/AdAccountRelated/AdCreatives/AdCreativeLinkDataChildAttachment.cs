using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataChildAttachment
    {
        [JsonProperty("call_to_action")]
        public AdCreativeLinkDataCallToAction CallToAction { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("caption_ids")]
        public List<long> CaptionIds { get; set; } = new List<long>();

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("place_data")]
        public AdCreativePlaceData PlaceData { get; set; }

        [JsonProperty("referral_id")]
        public long ReferralId { get; set; }

        [JsonProperty("static_card")]
        public bool StaticCard { get; set; }

        [JsonProperty("video_id")]
        public long VideoId { get; set; }
    }
}
