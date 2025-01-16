using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductFeedUpload
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("error_count")]
        public int ErrorCount { get; set; }

        [JsonProperty("error_report")]
        public ProductFeedUploadErrorReport ErrorReport { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("input_method")]
        public ProductFeedUploadInputMethod InputMethod { get; set; }

        [JsonProperty("num_deleted_items")]
        public int NumDeletedItems { get; set; }

        [JsonProperty("num_detected_items")]
        public int NumDetectedItems { get; set; }

        [JsonProperty("num_invalid_items")]
        public int NumInvalidItems { get; set; }

        [JsonProperty("num_persisted_items")]
        public int NumPersistedItems { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("warning_count")]
        public int WarningCount { get; set; }
    }
}
