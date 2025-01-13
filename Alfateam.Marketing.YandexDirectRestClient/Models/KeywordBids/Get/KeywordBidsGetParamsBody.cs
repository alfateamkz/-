using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class KeywordBidsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public KeywordBidsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<KeywordBidFieldEnum> FieldNames { get; set; } = new List<KeywordBidFieldEnum>();

        [JsonProperty("SearchFieldNames")]
        public List<KeywordBidSearchFieldEnum> SearchFieldNames { get; set; } = new List<KeywordBidSearchFieldEnum>();

        [JsonProperty("NetworkFieldNames")]
        public List<KeywordBidNetworkFieldEnum> NetworkFieldNames { get; set; } = new List<KeywordBidNetworkFieldEnum>();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
