using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords
{
    public class AutotargetingSettingsCategories
    {
        [JsonProperty("Exact")]
        public YesNoEnum Exact { get; set; }

        [JsonProperty("Narrow")]
        public YesNoEnum Narrow { get; set; }

        [JsonProperty("Alternative")]
        public YesNoEnum Alternative { get; set; }

        [JsonProperty("Accessory")]
        public YesNoEnum Accessory { get; set; }

        [JsonProperty("Broader")]
        public YesNoEnum Broader { get; set; }
    }
}
