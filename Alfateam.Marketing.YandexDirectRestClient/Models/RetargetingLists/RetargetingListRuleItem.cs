using Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists
{
    public class RetargetingListRuleItem
    {
        [JsonProperty("Arguments")]
        public List<RetargetingListRuleArgumentItem> Arguments { get; set; } = new List<RetargetingListRuleArgumentItem>();

        [JsonProperty("Operator")]
        public RetargetingListRuleOperatorEnum Operator { get; set; }
    }
}
