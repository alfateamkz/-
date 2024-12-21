using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls
{
    public class OfflineCallsUploading
    {
        [JsonProperty("client_id_type")]
        public ClientIdType ClientIdType { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("dynamic_calls_quantity")]
        public int DynamicCallsQuantity { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("line_quantity")]
        public int LineQuantity { get; set; }

        [JsonProperty("source_quantity")]
        public int SourceQuantity { get; set; }

        [JsonProperty("static_calls_quantity")]
        public int StaticCallsQuantity { get; set; }

        [JsonProperty("status")]
        public OfflineCallsUploadingStatus Status { get; set; }
    }
}
