using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs
{
    public class ProductCatalog
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("catalog_store")]
        public StoreCatalogSettings CatalogStore { get; set; }

        [JsonProperty("commerce_merchant_settings")]
        public CommerceMerchantSettings CommerceMerchantSettings { get; set; }

        [JsonProperty("da_display_settings")]
        public ProductCatalogImageSettings DADisplaySettings { get; set; }

        [JsonProperty("default_image_url")]
        public string DefaultImageURL { get; set; }

        [JsonProperty("fallback_image_url")]
        public List<string> FallbackImageURL { get; set; } = new List<string>();

        [JsonProperty("feed_count")]
        public int FeedCount { get; set; }

        [JsonProperty("is_catalog_segment")]
        public bool IsCatalogSegment { get; set; }

        [JsonProperty("is_local_catalog")]
        public bool IsLocalCatalog { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_count")]
        public int ProductCount { get; set; }

        [JsonProperty("store_catalog_settings")]
        public StoreCatalogSettings StoreCatalogSettings { get; set; }

        [JsonProperty("vertical")]
        public string Vertical { get; set; }
    }
}
