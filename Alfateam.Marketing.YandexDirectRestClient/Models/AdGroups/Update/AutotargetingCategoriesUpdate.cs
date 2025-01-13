using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Update
{
    public class AutotargetingCategoriesUpdate
    {
        [JsonProperty("Category")]
        public AutotargetingCategoryType Category { get; set; }

        [JsonProperty("Value")]
        public YesNoEnum Value { get; set; }
    }
}
