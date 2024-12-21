using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.RawDataReport
{
    public abstract class PushAPIConfig
    {
        [JsonProperty("method")]
        public PushAPIConfigMethod Method { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("attributing_entity")]
        public PushAPIConfigAttributingEntityType AttributingEntity { get; set; }
    }
}
