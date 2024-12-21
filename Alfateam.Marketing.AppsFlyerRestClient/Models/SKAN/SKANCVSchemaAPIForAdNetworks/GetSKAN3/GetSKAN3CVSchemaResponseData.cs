using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN3
{
    public class GetSKAN3CVSchemaResponseData
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("configuration_mode")]
        public string ConfigurationMode { get; set; }

        [JsonProperty("last_config_change")]
        public string LastConfigChange { get; set; }

        [JsonProperty("measurement_window")]
        public int MeasurementWindow { get; set; }

        [JsonProperty("conversion_value_mapping")]
        public List<GetSKAN3CVSchemaResponseConversionValueMapping> ConversionValueMapping { get; set; } = new List<GetSKAN3CVSchemaResponseConversionValueMapping>();
    }
}
