using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status
{
    public class DataStreamStatusStreamWindow
    {
        [JsonProperty("stream_window_timestamp")]
        public int StreamWindowTimestamp { get; set; }

        [JsonProperty("export_schema_id")]
        public int ExportSchemaId { get; set; }

        [JsonProperty("payload_bytes")]
        public int PayloadBytes { get; set; }

        [JsonProperty("event_count")]
        public int EventCount { get; set; }

        [JsonProperty("update_timestamp")]
        public int UpdateTimestamp { get; set; }
    }
}
