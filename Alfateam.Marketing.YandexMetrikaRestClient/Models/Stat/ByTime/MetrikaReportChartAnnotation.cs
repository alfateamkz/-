using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Stat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime
{
    public class MetrikaReportChartAnnotation
    {
        [JsonProperty("date")]
        public DateOnly Date { get; set; }

        [JsonProperty("group")]
        public MetrikaReportChartAnnotationGroup Group { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("time")]
        public TimeOnly Time { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
