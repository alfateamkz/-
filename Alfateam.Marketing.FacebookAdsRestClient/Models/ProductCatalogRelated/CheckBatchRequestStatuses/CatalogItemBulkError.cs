using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.CheckBatchRequestStatuses
{
    public class CatalogItemBulkError
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("line")]
        public int Line { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
