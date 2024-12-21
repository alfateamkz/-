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
    public class RegulariOSPushAPIConfig : PushAPIConfig
    {
        [JsonProperty("event_types")]
        public List<PushAPIConfigAppsFlyerEventType> EventTypes { get; set; } = new List<PushAPIConfigAppsFlyerEventType>();

        /// <summary>
        /// string или массив строк, см доку https://dev.appsflyer.com/hc/reference/put_app-app-id
        /// </summary>
        [JsonProperty("selected_fields")]
        public object SelectedFields { get; set; }


        /// <summary>
        /// string или массив строк, см доку https://dev.appsflyer.com/hc/reference/put_app-app-id
        /// </summary>
        [JsonProperty("selected_inapps")]
        public object SelectedInApps { get; set; }
    }
}
