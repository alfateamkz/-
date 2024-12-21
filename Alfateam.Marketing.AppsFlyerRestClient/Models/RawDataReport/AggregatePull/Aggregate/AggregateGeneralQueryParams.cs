using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.AggregatePull;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.AggregatePull.Aggregate
{
    public class AggregateGeneralQueryParams
    {
        [JsonProperty("from")]
        public DateOnly From { get; set; }

        [JsonProperty("to")]
        public DateOnly To { get; set; }

        [JsonProperty("media_source")]
        public string MediaSource { get; set; }

        [JsonProperty("category")]
        public RawDataReportCategory Category { get; set; }

        [JsonProperty("attribution_touch_type")]
        public RDAggregatePullAttributionTouchType? AttributionTouchType { get; set; }

        [JsonProperty("currency")]
        public RawDataReportCurrencyType Currency { get; set; }

        [JsonProperty("reattr")]
        public bool ReAttr { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
