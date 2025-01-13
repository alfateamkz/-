using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get
{
    public class AutotargetingSettingsGetItem
    {
        [JsonProperty("Categories")]
        public AutotargetingSettingsCategories Categories { get; set; }

        [JsonProperty("BrandOptions")]
        public AutotargetingSettingsBrandOptions BrandOptions { get; set; }
    }
}
