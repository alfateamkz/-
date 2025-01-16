using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductCatalogDiagnosticGroups
{
    public class ProductCatalogDiagnostic
    {
        [JsonProperty("action_uri")]
        public string ActionURI { get; set; }

        [JsonProperty("affected_properties")]
        public List<string> AffectedProperties { get; set; } = new List<string>();

        [JsonProperty("call_to_action")]
        public string CallToAction { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("event_source_id")]
        public string EventSourceId { get; set; }

        [JsonProperty("event_source_type")]
        public ProductCatalogDiagnosticEventSourceType EventSourceType { get; set; }

        [JsonProperty("instructions")]
        public List<string> Instructions { get; set; } = new List<string>();

        [JsonProperty("number_of_affected_entities")]
        public int NumberOfAffectedEntities { get; set; }

        [JsonProperty("number_of_affected_items")]
        public int NumberOfAffectedItems { get; set; }

        [JsonProperty("sample_affected_entities")]
        public List<ProductCatalogDiagnosticSampleEntity> SampleAffectedEntities { get; set; } = new List<ProductCatalogDiagnosticSampleEntity>();

        [JsonProperty("sample_affected_items")]
        public List<ProductCatalogDiagnosticSampleItem> SampleAffectedItems { get; set; } = new List<ProductCatalogDiagnosticSampleItem>();

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
