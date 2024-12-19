using Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Analytics.Cohort
{
    public class CohortReportBody
    {
        [JsonProperty("cohort_type")]
        public CohortType CohortType { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        [JsonProperty("kpis")]
        public List<CohortKPIType> KPIs { get; set; } = new List<CohortKPIType>();


        [JsonProperty("aggregation_type")]
        public CohortAggregationType AggregationType { get; set; } 


        public List<CohortGroupingsType> Groupings { get; set; } = new List<CohortGroupingsType>();

        [JsonProperty("min_cohort_size")]
        public int MinCohortSize { get; set; } = 1;

        public CohortGranularity Granularity { get; set; } = CohortGranularity.Hour;
      
        [JsonProperty("partial_data")]
        public bool PartialData { get; set; } = false;


        public CohortReportBodyFilters Filters { get; set; } = new CohortReportBodyFilters();

        [JsonProperty("preferred_currency")]
        public bool PreferredCurrency { get; set; } = false;

        [JsonProperty("preferred_timezone")]
        public bool PreferredTimezone { get; set; } = false;

        [JsonProperty("per_user")]
        public bool PerUser { get; set; } = false;
    }
}
