using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class ContextCoverage
    {
        [JsonProperty("Items")]
        public List<ContextCoverageItem> Items { get; set; } = new List<ContextCoverageItem>();
    }
}
