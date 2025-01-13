using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.HasSearchVolume
{
    public class KeywordsResearchHasSearchVolumeParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public HasSearchVolumeSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<HasSearchVolumeFieldEnum> FieldNames { get; set; } = new List<HasSearchVolumeFieldEnum>();
    }
}
