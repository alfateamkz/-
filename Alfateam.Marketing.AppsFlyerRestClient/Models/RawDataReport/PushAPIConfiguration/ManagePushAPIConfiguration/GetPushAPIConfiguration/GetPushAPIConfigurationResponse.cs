using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.RawDataReport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.GetPushAPIConfiguration
{
    public class GetPushAPIConfigurationResponse
    {
        [JsonProperty("endpoints")]
        public List<PushAPIConfig> Endpoints { get; set; } = new List<PushAPIConfig>();
    }
}
