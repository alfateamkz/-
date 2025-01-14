using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeObjectStorySpec
    {
        [JsonProperty("instagram_actor_id")]
        public string InstagramActorId { get; set; }

        [JsonProperty("link_data")]
        public AdCreativeLinkData LinkData { get; set; }

        [JsonProperty("page_id")]
        public long PageId { get; set; }

        [JsonProperty("photo_data")]
        public AdCreativePhotoData PhotoData { get; set; }

        [JsonProperty("product_data")]
        public List<AdCreativeProductData> ProductData { get; set; } = new List<AdCreativeProductData>();

        [JsonProperty("template_data")]
        public AdCreativeLinkData TemplateData { get; set; }

        [JsonProperty("text_data")]
        public AdCreativeTextData TextData { get; set; }

        [JsonProperty("video_data")]
        public AdCreativeVideoData VideoData { get; set; }
    }
}
