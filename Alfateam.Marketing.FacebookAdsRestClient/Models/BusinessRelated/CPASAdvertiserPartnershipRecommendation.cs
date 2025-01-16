using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class CPASAdvertiserPartnershipRecommendation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("advertiser_business_id")]
        public long AdvertiserBusinessId { get; set; }

        [JsonProperty("brand_business_id")]
        public long BrandBusinessId { get; set; }

        [JsonProperty("brands")]
        public List<string> Brands { get; set; } = new List<string>();

        [JsonProperty("countries")]
        public List<string> Countries { get; set; } = new List<string>();

        [JsonProperty("merchant_business_id")]
        public long MerchantBusinessId { get; set; }

        [JsonProperty("merchant_categories")]
        public List<string> MerchantCategories { get; set; } = new List<string>();

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_reason")]
        public string StatusReason { get; set; }
    }
}
