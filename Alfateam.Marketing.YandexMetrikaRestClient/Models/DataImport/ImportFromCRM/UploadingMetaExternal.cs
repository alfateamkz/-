using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM
{
    public class UploadingMetaExternal
    {
        [JsonProperty("api_validation_status")]
        public APIValidationStatus APIValidationStatus { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("elements_count")]
        public int ElementsCount { get; set; }

        [JsonProperty("entity_type")]
        public UploadingMetaExternalEntityType EntityType { get; set; }

        [JsonProperty("uploading_format")]
        public UploadingFormat UploadingFormat { get; set; }

        [JsonProperty("uploading_id")]
        public string UploadingId { get; set; }

        [JsonProperty("uploading_source")]
        public UploadingMetaExternalUploadingSource UploadingSource { get; set; }
    }
}
