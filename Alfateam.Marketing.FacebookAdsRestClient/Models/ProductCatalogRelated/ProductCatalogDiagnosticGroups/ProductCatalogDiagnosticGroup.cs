using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductCatalogDiagnosticGroups
{
    public class ProductCatalogDiagnosticGroup
    {
        [JsonProperty("affected_channels")]
        public List<string> AffectedChannels { get; set; } = new List<string>();

        [JsonProperty("affected_entity")]
        public ProductCatalogDiagnosticGroupAffectedEntity AffectedEntity { get; set; }

        [JsonProperty("affected_features")]
        public List<ProductCatalogDiagnosticGroupAffectedFeature> AffectedFeatures { get; set; } = new List<ProductCatalogDiagnosticGroupAffectedFeature>();

        [JsonProperty("diagnostics")]
        public List<ProductCatalogDiagnostic> Diagnostics { get; set; } = new List<ProductCatalogDiagnostic>();

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("number_of_affected_entities")]
        public int NumberOfAffectedEntities { get; set; }

        [JsonProperty("number_of_affected_items")]
        public int NumberOfAffectedItems { get; set; }

        [JsonProperty("severity")]
        public ProductCatalogDiagnosticGroupSeverity Severity { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public ProductCatalogDiagnosticGroupType Type { get; set; }
    }
}
