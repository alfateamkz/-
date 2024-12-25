using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions.Models.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data
{
    public class ReportsDataResponse : ReportBase
    {
        [JsonProperty("data")]
        public ReportsDataResponseData Data { get; set; }
    }
}
