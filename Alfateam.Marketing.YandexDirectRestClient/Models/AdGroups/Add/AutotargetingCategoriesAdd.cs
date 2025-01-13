using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class AutotargetingCategoriesAdd
    {
        [JsonProperty("Category")]
        public AutotargetingCategoryType Category { get; set; }

        [JsonProperty("Value")]
        public YesNoEnum Value { get; set; }
    }
}
