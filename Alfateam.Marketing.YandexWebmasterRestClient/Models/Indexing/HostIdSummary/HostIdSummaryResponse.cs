using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdSummary
{
    public class HostIdSummaryResponse
    {
        [JsonProperty("sqi")]
        public int SQI { get; set; }

        [JsonProperty("excluded_pages_count")]
        public long ExcludedPagesCount { get; set; }

        [JsonProperty("searchable_pages_count")]
        public long SearchablePagesCount { get; set; }

        [JsonProperty("site_problems")]
        public Dictionary<SiteProblemSeverityEnum, int> SiteProblems { get; set; } = new Dictionary<SiteProblemSeverityEnum, int>();
    }
}
