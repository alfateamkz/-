using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativePlatformCustomizationOverride
    {
        [JsonProperty("caption_ids")]
        public List<long> CaptionIds { get; set; } = new List<long>();

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("image_url")]
        public string ImageURL { get; set; }

        [JsonProperty("video_id")]
        public long VideoId { get; set; }
    }
}
