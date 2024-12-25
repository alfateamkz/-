using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream
{
    public class DataStreamSettings
    {
        [JsonProperty("ui_checkbox_enabled")]
        public bool UICheckboxEnabled { get; set; }

        [JsonProperty("export_fields")]
        public List<DataStreamSettingsExportField> ExportFields { get; set; } = new List<DataStreamSettingsExportField>();
    }
}
