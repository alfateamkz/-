using Alfateam.Marketing.YandexDirectRestClient.Enums.AdVideos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Get
{
    public class AdVideosGetParamsBody
    {
        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }

        [JsonProperty("SelectionCriteria")]
        public AdVideosSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AdVideosFieldEnum> FieldNames { get; set; } = new List<AdVideosFieldEnum>()
        {
            AdVideosFieldEnum.Id,
            AdVideosFieldEnum.Status
        };
    }
}
