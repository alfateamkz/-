using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations
{
    public class WithChartAnnotationBody
    {
        [JsonProperty("chart_annotation")]
        public MetrikaChartAnnotation ChartAnnotation { get; set; }
    }
}
