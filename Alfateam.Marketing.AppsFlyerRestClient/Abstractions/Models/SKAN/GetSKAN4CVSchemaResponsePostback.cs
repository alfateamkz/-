using Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.SKAN
{
    public abstract class GetSKAN4CVSchemaResponsePostback
    {
        [JsonProperty("postback_sequence_index")]
        public int PostbackSequenceIndex { get; set; }

        [JsonProperty("measurement_window")]
        public int MeasurementWindow { get; set; }

        [JsonProperty("lock_window_type")]
        public SKAN4CVSchemaPostbackLockWindowType LockWindowType { get; set; }

        [JsonProperty("lock_window_event")]
        public string LockWindowEvent { get; set; }
    }
}
