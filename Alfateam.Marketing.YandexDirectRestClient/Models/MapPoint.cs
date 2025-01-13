using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class MapPoint
    {
        [JsonProperty("X")]
        public decimal X { get; set; }

        [JsonProperty("Y")]
        public decimal Y { get; set; }

        [JsonProperty("X1")]
        public decimal X1 { get; set; }

        [JsonProperty("Y1")]
        public decimal Y1 { get; set; }

        [JsonProperty("X2")]
        public decimal X2 { get; set; }

        [JsonProperty("Y2")]
        public decimal Y2 { get; set; }
    }
}
