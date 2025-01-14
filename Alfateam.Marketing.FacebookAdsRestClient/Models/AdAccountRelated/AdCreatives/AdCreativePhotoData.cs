using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativePhotoData
    {
        [JsonProperty("branded_content_shared_to_sponsor_status")]
        public string BrandedContentSharedToSponsorStatus { get; set; }

        [JsonProperty("branded_content_sponsor_page_id")]
        public long BrandedContentSponsorPageId { get; set; }

        [JsonProperty("branded_content_sponsor_relationship")]
        public string BrandedContentSponsorRelationship { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("page_welcome_message")]
        public string PageWelcomeMessage { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
