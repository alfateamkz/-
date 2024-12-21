using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data
{
    public class StaticRow
    {
        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; } = new List<string>();

        [JsonProperty("metrics")]
        public List<double> Metrics { get; set; } = new List<double>();
    }
}
