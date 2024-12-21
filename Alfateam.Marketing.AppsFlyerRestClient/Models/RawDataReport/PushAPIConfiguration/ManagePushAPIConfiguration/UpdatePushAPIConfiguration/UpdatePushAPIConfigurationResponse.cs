using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.UpdatePushAPIConfiguration
{
    public class UpdatePushAPIConfigurationResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
