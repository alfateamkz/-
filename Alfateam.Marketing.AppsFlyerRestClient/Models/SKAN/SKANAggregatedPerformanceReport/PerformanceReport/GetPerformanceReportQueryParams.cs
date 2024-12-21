using Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANAggregatedPerformanceReport.PerformanceReport
{
    public class GetPerformanceReportQueryParams
    {
        [JsonProperty("date_type")]
        public GetPerformanceReportQueryParamsDateType DateType { get; set; }

        [JsonProperty("start_date")]
        public DateOnly StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateOnly EndDate { get; set; }

        [JsonProperty("view_type")]
        public GetPerformanceReportQueryParamsViewType ViewType { get; set; }

        [JsonProperty("modeled_conversion_values")]
        public bool ModeledConversionValues { get; set; }
    }
}
