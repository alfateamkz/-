using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class MobileAppAdFeatureItem
    {
        [JsonProperty("Feature")]
        public MobileAppFeatureEnum Feature { get; set; }

        [JsonProperty("Enabled")]
        public YesNoEnum Enabled { get; set; }
    }
}
