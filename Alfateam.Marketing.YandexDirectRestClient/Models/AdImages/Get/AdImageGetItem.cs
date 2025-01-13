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
    public class AdImageGetItem
    {
        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Associated")]
        public YesNoEnum Associated { get; set; }

        [JsonProperty("Type")]
        public AdImageTypeEnum Type { get; set; }

        [JsonProperty("Subtype")]
        public AdImageSubtypeEnum Subtype { get; set; }

        [JsonProperty("OriginalUrl")]
        public string OriginalUrl { get; set; }

        [JsonProperty("PreviewUrl")]
        public string PreviewUrl { get; set; }
    }
}
