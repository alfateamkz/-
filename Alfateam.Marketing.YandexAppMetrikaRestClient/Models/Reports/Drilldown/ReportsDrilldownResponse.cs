using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions.Models.Reports;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Drilldown
{
    public class ReportsDrilldownResponse : ReportBase
    {
        [JsonProperty("data")]
        public ReportsDrilldownResponseData Data { get; set; }
    }
}
