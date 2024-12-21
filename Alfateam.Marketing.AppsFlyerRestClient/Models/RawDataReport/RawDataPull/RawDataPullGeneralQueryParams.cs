using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull
{
    public class RawDataPullGeneralQueryParams
    {
        [JsonProperty("from")]
        public DateOnly From { get; set; }

        [JsonProperty("to")]
        public DateOnly To { get; set; }

        [JsonProperty("media_source")]
        public string MediaSource { get; set; }

        [JsonProperty("category")]
        public RawDataReportCategory Category { get; set; }

        [JsonProperty("currency")]
        public RawDataReportCurrencyType Currency { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("geo")]
        public string Geo { get; set; }

        [JsonProperty("maximum_rows")]
        public RawDataReport200k1mMaxRowsCount? MaximumRows { get; set; }

        [JsonProperty("from_install_time")]
        public DateOnly FromInstallTime { get; set; }

        [JsonProperty("to_install_time")]
        public DateOnly ToInstallTime { get; set; }

        [JsonProperty("agency")]
        public List<string> Agency { get; set; } = new List<string>();

        [JsonProperty("additional_fields")]
        public List<RawDataReportAdditionalFieldType> AdditionalFields { get; set; } = new List<RawDataReportAdditionalFieldType>();
    }
}
