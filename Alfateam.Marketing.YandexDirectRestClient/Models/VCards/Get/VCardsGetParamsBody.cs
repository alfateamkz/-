using Alfateam.Marketing.YandexDirectRestClient.Enums.VCards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards.Get
{
    public class VCardsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public IdsCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<VCardFieldEnum> FieldNames { get; set; } = Enum.GetValues<VCardFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
