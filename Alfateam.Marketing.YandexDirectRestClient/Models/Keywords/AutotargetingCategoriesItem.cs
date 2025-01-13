using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords
{
    public class AutotargetingCategoriesItem
    {
        [JsonProperty("Category")]
        public AutotargetingCategoriesEnum Category { get; set; }

        [JsonProperty("Value")]
        public YesNoEnum Value { get; set; }
    }
}
