using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Get
{
    public class CreativeGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Type")]
        public CreativeTypeEnum Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PreviewUrl")]
        public string PreviewUrl { get; set; }

        [JsonProperty("Width")]
        public int Width { get; set; }

        [JsonProperty("Height")]
        public int Height { get; set; }

        [JsonProperty("ThumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("Associated")]
        public YesNoEnum Associated { get; set; }

        [JsonProperty("IsAdaptive")]
        public YesNoEnum IsAdaptive { get; set; }

        [JsonProperty("VideoExtensionCreative")]
        public VideoExtensionCreativeGet VideoExtensionCreative { get; set; }

        [JsonProperty("CpcVideoCreative")]
        public CpcVideoCreativeGet CpcVideoCreative { get; set; }

        [JsonProperty("CpmVideoCreative")]
        public CpmVideoCreativeGet CpmVideoCreative { get; set; }

        [JsonProperty("SmartCreative")]
        public SmartCreativeGet SmartCreative { get; set; }
    }
}
