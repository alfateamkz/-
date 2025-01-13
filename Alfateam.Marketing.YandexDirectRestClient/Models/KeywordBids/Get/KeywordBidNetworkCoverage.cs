using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class KeywordBidNetworkCoverage
    {
        [JsonProperty("CoverageItems")]
        public List<KeywordBidNetworkCoverageItem> CoverageItems { get; set; } = new List<KeywordBidNetworkCoverageItem>();
    }
}
