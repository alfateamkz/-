using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions.Models.Reports
{
    public abstract class ReportBase
    {
        [JsonProperty("total_rows")]
        public long total_rows { get; set; }

        [JsonProperty("sampled")]
        public bool sampled { get; set; }

        [JsonProperty("sample_share")]
        public double sample_share { get; set; }

        [JsonProperty("sample_size")]
        public long sample_size { get; set; }

        [JsonProperty("sample_space")]
        public long sample_space { get; set; }

        [JsonProperty("data_lag")]
        public long data_lag { get; set; }

        [JsonProperty("query")]
        public ReportsDataResponseQuery Query { get; set; }

        [JsonProperty("totals")]
        public List<double> Totals { get; set; } = new List<double>();

        [JsonProperty("min")]
        public List<double> Min { get; set; } = new List<double>();

        [JsonProperty("max")]
        public List<double> Max { get; set; } = new List<double>();
    }
}
