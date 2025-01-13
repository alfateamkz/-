using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class UnifiedAdGroupGet
    {
        [JsonProperty("OfferRetargeting")]
        public YesNoEnum OfferRetargeting { get; set; }
    }
}
