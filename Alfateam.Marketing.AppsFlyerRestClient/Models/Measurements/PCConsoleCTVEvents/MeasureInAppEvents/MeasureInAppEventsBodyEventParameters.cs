using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureInAppEvents
{
    public class MeasureInAppEventsBodyEventParameters
    {
        [JsonProperty("af_revenue")]
        public double AFRevenue { get; set; }

        [JsonProperty("af_currency")]
        public string AFCurrency { get; set; }
    }
}
