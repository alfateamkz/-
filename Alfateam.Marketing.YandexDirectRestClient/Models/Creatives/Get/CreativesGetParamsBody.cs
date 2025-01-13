using Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class CreativesGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public CreativesSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AdFieldEnum> FieldNames { get; set; } = Enum.GetValues<AdFieldEnum>().ToList();

        [JsonProperty("VideoExtensionCreativeFieldNames")]
        public List<VideoExtensionCreativeFieldNames> VideoExtensionCreativeFieldNames { get; set; } = Enum.GetValues<VideoExtensionCreativeFieldNames>().ToList();

        [JsonProperty("CpcVideoCreativeFieldNames")]
        public List<CpcVideoCreativeFieldEnum> CpcVideoCreativeFieldNames { get; set; } = Enum.GetValues<CpcVideoCreativeFieldEnum>().ToList();

        [JsonProperty("CpmVideoCreativeFieldNames")]
        public List<CpmVideoCreativeFieldEnum> CpmVideoCreativeFieldNames { get; set; } = Enum.GetValues<CpmVideoCreativeFieldEnum>().ToList();

        [JsonProperty("SmartCreativeFieldNames")]
        public List<SmartCreativeFieldEnum> SmartCreativeFieldNames { get; set; } = Enum.GetValues<SmartCreativeFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
