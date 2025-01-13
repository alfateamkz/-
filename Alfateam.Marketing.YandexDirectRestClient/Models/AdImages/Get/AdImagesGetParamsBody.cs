using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Get
{
    public class AdImagesGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public AdImageSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AdImageFieldEnum> FieldNames { get; set; } = new List<AdImageFieldEnum>()
        {
            AdImageFieldEnum.AdImageHash,
            AdImageFieldEnum.OriginalUrl,
            AdImageFieldEnum.PreviewUrl,
            AdImageFieldEnum.Name,
            AdImageFieldEnum.Type,
            AdImageFieldEnum.Subtype,
            AdImageFieldEnum.Associated,
        };

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
