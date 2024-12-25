using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status
{
    public class DataStreamStatus
    {
        [JsonProperty("streams")]
        public List<DataStreamStatusStream> Streams { get; set; } = new List<DataStreamStatusStream>();

        [JsonProperty("export_fields")]
        public List<DataStreamStatusExportField> ExportFields { get; set; } = new List<DataStreamStatusExportField>();
    }
}
