using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedAdditionalData
    {
        [JsonProperty("automated_product_tags")]
        public bool AutomatedProductTags { get; set; }

        [JsonProperty("brand_page_id")]
        public long BrandPageId { get; set; }

        [JsonProperty("is_click_to_message")]
        public bool IsClickToMessage { get; set; }

        [JsonProperty("multi_share_end_card")]
        public bool MultiShareEndCard { get; set; }

        [JsonProperty("page_welcome_message")]
        public string PageWelcomeMessage { get; set; }

        [JsonProperty("partner_app_welcome_message_flow_id")]
        public long PartnerAppWelcomeMessageFlowId { get; set; }
    }
}
