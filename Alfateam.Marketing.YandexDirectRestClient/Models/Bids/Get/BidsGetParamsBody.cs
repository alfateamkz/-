using Alfateam.Marketing.YandexDirectRestClient.Enums.Bids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class BidsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public BidsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<BidFieldEnum> FieldNames { get; set; } = Enum.GetValues<BidFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
