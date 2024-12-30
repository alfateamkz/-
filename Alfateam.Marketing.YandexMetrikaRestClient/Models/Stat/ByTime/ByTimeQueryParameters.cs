using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.ChartAnnotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime
{
    public class ByTimeQueryParameters : StatGeneralQueryParams
    {
        [JsonProperty("annotation_groups")]
        public string annotation_groups { get; set; }
    }
}
