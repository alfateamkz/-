using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductItemError
    {
        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("error_priority")]
        public ErrorPriority error_priority { get; set; }

        [JsonProperty("error_type")]
        public string error_type { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
