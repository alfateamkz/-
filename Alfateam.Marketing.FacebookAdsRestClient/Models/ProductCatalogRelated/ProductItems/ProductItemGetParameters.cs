using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductItemGetParameters
    {
        [JsonProperty("catalog_id")]
        public long CatalogId { get; set; }

        [JsonProperty("image_height")]
        public long ImageHeight { get; set; }

        [JsonProperty("image_width")]
        public long ImageWidth { get; set; }

        [JsonProperty("override_country")]
        public string OverrideCountry { get; set; }

        [JsonProperty("override_language")]
        public string OverrideLanguage { get; set; }
    }
}
