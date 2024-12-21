using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.RawDataReport;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.Configs
{
    public class SKadNetworkiOSPushAPIConfig : PushAPIConfig
    {
        [JsonProperty("event_types")]
        public List<PushAPIConfigSKAdEventType> EventTypes { get; set; } = new List<PushAPIConfigSKAdEventType>();
    }
}
