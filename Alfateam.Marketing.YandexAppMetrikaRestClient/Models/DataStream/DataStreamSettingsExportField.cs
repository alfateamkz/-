using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.DataStream;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream
{
    public class DataStreamSettingsExportField
    {
        [JsonProperty("data_type")]
        public DataStreamDataType DataType { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("export_format")]
        public DataStreamExportFormat ExportFormat { get; set; }

        [JsonProperty("fields")]
        public List<string> Fields { get; set; } = new List<string>();

        [JsonProperty("include_events")]
        public List<string> IncludeEvents { get; set; } = new List<string>();

        [JsonProperty("exclude_events")]
        public List<string> ExcludeEvents { get; set; } = new List<string>();
    }
}
