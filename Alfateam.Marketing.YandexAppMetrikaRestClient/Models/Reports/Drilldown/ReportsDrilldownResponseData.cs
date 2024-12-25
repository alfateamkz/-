using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Drilldown
{
    public class ReportsDrilldownResponseData
    {
        [JsonProperty("dimensions")]
        public List<Dictionary<string, string>> Dimensions { get; set; } = new List<Dictionary<string, string>>();

        [JsonProperty("metrics")]
        public List<double> Metrics { get; set; } = new List<double>();

        [JsonProperty("expand")]
        public bool Expand { get; set; }
    }
}
