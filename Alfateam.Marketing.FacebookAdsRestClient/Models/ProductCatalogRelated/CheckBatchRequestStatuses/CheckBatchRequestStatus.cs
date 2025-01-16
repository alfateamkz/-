using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.CheckBatchRequestStatuses
{
    public class CheckBatchRequestStatus
    {
        [JsonProperty("errors")]
        public List<CatalogItemBulkError> Errors { get; set; } = new List<CatalogItemBulkError>();

        [JsonProperty("errors_total_count")]
        public int ErrorsTotalCount { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("ids_of_invalid_requests")]
        public List<string> IdsOfInvalidRequests { get; set; } = new List<string>();

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("warnings")]
        public List<CatalogItemBulkError> Warnings { get; set; } = new List<CatalogItemBulkError>();

        [JsonProperty("warnings_total_count")]
        public int WarningsTotalCount { get; set; }
    }
}
