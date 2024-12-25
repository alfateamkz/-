using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports
{
    public class ReportsGeneralQueryParams
    {
        [JsonProperty("ids")]
        public List<int> Ids { get; set; } = new List<int>();

        [JsonProperty("metrics")]
        public string Metrics { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("date1")]
        public DateTime Date1 { get; set; }

        [JsonProperty("date2")]
        public DateTime Date2 { get; set; }

        [JsonProperty("dimensions")]
        public string Dimensions { get; set; }

        [JsonProperty("filters")]
        public string Filters { get; set; }

        [JsonProperty("group")]
        public ReportsDateGroupType Group { get; set; }

        [JsonProperty("include_undefined")]
        public bool Include_Undefined { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("pretty")]
        public bool Pretty { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }
    }
}
