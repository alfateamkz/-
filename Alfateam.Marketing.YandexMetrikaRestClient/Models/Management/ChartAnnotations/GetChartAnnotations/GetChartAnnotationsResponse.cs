using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations.GetChartAnnotations
{
    public class GetChartAnnotationsResponse
    {
        [JsonProperty("chart_annotations")]
        public List<MetrikaChartAnnotation> ChartAnnotations { get; set; } = new List<MetrikaChartAnnotation>();
    }
}
