using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data
{
    public class ReportsDataResponseQuery
    {
        [JsonProperty("ids")]
        public List<int> Ids { get; set; } = new List<int>();

        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; } = new List<string>();

        [JsonProperty("metrics")]
        public List<string> Metrics { get; set; } = new List<string>();

        [JsonProperty("sort")]
        public List<string> Sort { get; set; } = new List<string>();

        [JsonProperty("date1")]
        public DateTime Date1 { get; set; }

        [JsonProperty("date2")]
        public DateTime Date2 { get; set; }

        [JsonProperty("filters")]
        public string Filters { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
