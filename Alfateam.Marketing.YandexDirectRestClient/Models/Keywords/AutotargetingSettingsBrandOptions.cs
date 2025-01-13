using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords
{
    public class AutotargetingSettingsBrandOptions
    {
        [JsonProperty("WithoutBrands")]
        public YesNoEnum WithoutBrands { get; set; }

        [JsonProperty("WithAdvertiserBrand")]
        public YesNoEnum WithAdvertiserBrand { get; set; }

        [JsonProperty("WithCompetitorsBrand")]
        public YesNoEnum WithCompetitorsBrand { get; set; }
    }
}
