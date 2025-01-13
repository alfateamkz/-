using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class TextAdAdd
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Title2")]
        public string Title2 { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Href")]
        public string Href { get; set; }

        [JsonProperty("Mobile")]
        public YesNoEnum Mobile { get; set; }

        [JsonProperty("DisplayUrlPath")]
        public string DisplayUrlPath { get; set; }

        [JsonProperty("VCardId")]
        public long VCardId { get; set; }

        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("SitelinkSetId")]
        public long SitelinkSetId { get; set; }

        [JsonProperty("AdExtensionIds")]
        public List<long> AdExtensionIds { get; set; } = new List<long>();

        [JsonProperty("VideoExtension")]
        public VideoExtensionAddItem VideoExtension { get; set; }

        [JsonProperty("PriceExtension")]
        public PriceExtensionAddItem PriceExtension { get; set; }

        [JsonProperty("TurboPageId")]
        public long TurboPageId { get; set; }

        [JsonProperty("BusinessId")]
        public long BusinessId { get; set; }

        [JsonProperty("PreferVCardOverBusiness")]
        public YesNoEnum PreferVCardOverBusiness { get; set; }

        [JsonProperty("ErirAdDescription")]
        public string ErirAdDescription { get; set; }
    }
}
