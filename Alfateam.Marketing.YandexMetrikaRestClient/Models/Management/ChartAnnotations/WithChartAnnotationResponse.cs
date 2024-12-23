using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations
{
    public class WithChartAnnotationResponse
    {
        [JsonProperty("chart_annotation")]
        public MetrikaChartAnnotation ChartAnnotation { get; set; }
    }
}
