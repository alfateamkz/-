using Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.GetGeoRegions
{
    public class DictionariesGetGeoRegionsParamsBody
    {
        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }

        [JsonProperty("SelectionCriteria")]
        public GeoRegionsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<DictionaryGeoFieldEnum> FieldNames { get; set; } = new List<DictionaryGeoFieldEnum>();
    }
}
