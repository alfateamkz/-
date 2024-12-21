using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.Master.MasterReport.GetMasterReport
{
    public class GetMasterReportQueryParams
    {
        [JsonProperty("from")]
        public DateOnly From { get; set; }

        [JsonProperty("to")]
        public DateOnly To { get; set; }

        [JsonProperty("groupings")]
        public List<MasterReportGroupingType> Groupings { get; set; } = new List<MasterReportGroupingType>();

        [JsonProperty("kpis")]
        public List<string> KPIs { get; set; } = new List<string>();

        [JsonProperty("calculated_kpis")]
        public Dictionary<string, string> CalculatedKPIs { get; set; } = new Dictionary<string, string>();

        [JsonProperty("pid")]
        public List<string> Pid { get; set; } = new List<string>();

        [JsonProperty("c")]
        public List<string> C { get; set; } = new List<string>();

        [JsonProperty("af_prt")]
        public List<string> AFPrt { get; set; } = new List<string>();

        [JsonProperty("af_channel")]
        public List<string> AFChannel { get; set; } = new List<string>();

        [JsonProperty("af_siteid")]
        public List<string> AFSiteid { get; set; } = new List<string>();

        [JsonProperty("geo")]
        public List<string> Geo { get; set; } = new List<string>();

        [JsonProperty("currency")]
        public RawDataReportCurrencyType Currency { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("format")]
        public string Format => "json";
    }
}
