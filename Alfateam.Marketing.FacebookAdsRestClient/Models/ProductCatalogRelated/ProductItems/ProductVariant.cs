using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductVariant
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("options")]
        public List<string> Options { get; set; } = new List<string>();

        [JsonProperty("product_field")]
        public string ProductField { get; set; }
    }
}
