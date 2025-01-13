using Alfateam.Marketing.YandexDirectRestClient.Enums.Businesses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Businesses.Get
{
    public class BusinessesGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public IdsCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<BusinessFieldEnum> FieldNames { get; set; } = Enum.GetValues<BusinessFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
