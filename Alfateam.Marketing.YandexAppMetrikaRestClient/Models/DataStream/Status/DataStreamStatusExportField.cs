using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status
{
    public class DataStreamStatusExportField
    {
        [JsonProperty("export_schema_id")]
        public int ExportSchemaId { get; set; }

        [JsonProperty("field_names")]
        public List<string> FieldNames { get; set; } = new List<string>();
    }
}
