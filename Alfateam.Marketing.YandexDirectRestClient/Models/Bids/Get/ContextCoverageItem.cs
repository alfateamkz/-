using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class ContextCoverageItem
    {
        [JsonProperty("Probability")]
        public decimal Probability { get; set; }

        [JsonProperty("Price")]
        public long Price { get; set; }
    }
}
