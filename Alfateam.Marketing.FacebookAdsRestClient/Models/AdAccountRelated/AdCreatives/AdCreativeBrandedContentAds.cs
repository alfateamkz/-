using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeBrandedContentAds
    {
        [JsonProperty("ad_format")]
        public int AdFormat { get; set; }

        [JsonProperty("content_search_input")]
        public string ContentSearchInput { get; set; }

        [JsonProperty("creator_ad_permission_type")]
        public string CreatorAdPermissionType { get; set; }

        [JsonProperty("is_mca_internal")]
        public bool IsMCAInternal { get; set; }

        [JsonProperty("parent_source_facebook_post_id")]
        public long ParentSourceFacebookPostId { get; set; }

        [JsonProperty("parent_source_instagram_media_id")]
        public long ParentSourceInstagramMediaId { get; set; }

        [JsonProperty("partners")]
        public List<AdCreativeBrandedContentAdsPartners> Partners { get; set; } = new List<AdCreativeBrandedContentAdsPartners>();

        [JsonProperty("product_set_partner_selection_status")]
        public string ProductSetPartnerSelectionStatus { get; set; }

        [JsonProperty("promoted_page_id")]
        public long PromotedPageId { get; set; }

        [JsonProperty("testimonial")]
        public string Testimonial { get; set; }
    }
}
