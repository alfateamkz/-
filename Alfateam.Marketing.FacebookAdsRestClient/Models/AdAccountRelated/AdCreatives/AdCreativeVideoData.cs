using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeVideoData
    {
        [JsonProperty("additional_image_index")]
        public int AdditionalImageIndex { get; set; }

        [JsonProperty("branded_content_shared_to_sponsor_status")]
        public string BrandedContentSharedToSponsorStatus { get; set; }

        [JsonProperty("branded_content_sponsor_page_id")]
        public long BrandedContentSponsorPageId { get; set; }

        [JsonProperty("branded_content_sponsor_relationship")]
        public string BrandedContentSponsorRelationship { get; set; }

        [JsonProperty("call_to_action")]
        public AdCreativeLinkDataCallToAction CallToAction { get; set; }

        [JsonProperty("caption_ids")]
        public List<long> CaptionIds { get; set; } = new List<long>();

        [JsonProperty("collection_thumbnails")]
        public List<AdCreativeCollectionThumbnailInfo> CollectionThumbnails { get; set; } = new List<AdCreativeCollectionThumbnailInfo>();

        [JsonProperty("customization_rules_spec")]
        public List<AdCustomizationRuleSpec> CustomizationRulesSpec { get; set; } = new List<AdCustomizationRuleSpec>();

        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        [JsonProperty("image_url")]
        public string ImageURL { get; set; }

        [JsonProperty("link_description")]
        public string LinkDescription { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("offer_id")]
        public long OfferId { get; set; }

        [JsonProperty("page_welcome_message")]
        public string PageWelcomeMessage { get; set; }

        [JsonProperty("post_click_configuration")]
        public AdCreativePostClickConfiguration PostClickConfiguration { get; set; }

        [JsonProperty("retailer_item_ids")]
        public List<string> RetailerItemIds { get; set; } = new List<string>();

        [JsonProperty("targeting")]
        public Targeting Targeting { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video_id")]
        public long VideoId { get; set; }
    }
}
