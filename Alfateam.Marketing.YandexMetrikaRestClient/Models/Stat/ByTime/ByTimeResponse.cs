using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime
{
    public class ByTimeResponse : StatGeneralResponse
    {
        [JsonProperty("annotations")]
        public List<List<MetrikaReportChartAnnotation>> Annotations { get; set; } = new List<List<MetrikaReportChartAnnotation>>();

        [JsonProperty("data")]
        public List<DynamicRow> Data { get; set; } = new List<DynamicRow>();

        [JsonProperty("query")]
        public DynamicQueryExternal Query { get; set; }
    }
}
