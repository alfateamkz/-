using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4
{
    public class GetSKAN4CVSchemaResponseData
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("configuration_mode")]
        public string ConfigurationMode { get; set; }

        [JsonProperty("last_config_change")]
        public string LastConfigChange { get; set; }

        [JsonProperty("measurement_window")]
        public int MeasurementWindow { get; set; }

        [JsonProperty("postbacks")]
        public List<GetSKAN4CVSchemaResponsePostback> Postbacks { get; set; } = new List<GetSKAN4CVSchemaResponsePostback>();
    }
}
