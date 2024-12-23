using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Diagnostics
{
    public class DiagnosticsResponseProblem
    {
        [JsonProperty("severity")]
        public SiteProblemSeverityEnum Severity { get; set; }

        [JsonProperty("state")]
        public SiteProblemState State { get; set; }

        [JsonProperty("last_state_update")]
        public DateTime LastStateUpdate { get; set; }
    }
}
