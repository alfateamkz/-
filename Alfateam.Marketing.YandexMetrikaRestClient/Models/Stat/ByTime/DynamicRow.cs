using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime
{
    public class DynamicRow
    {
        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; } = new List<string>();

        [JsonProperty("metrics")]
        public List<List<double>> Metrics { get; set; } = new List<List<double>>();
    }
}
