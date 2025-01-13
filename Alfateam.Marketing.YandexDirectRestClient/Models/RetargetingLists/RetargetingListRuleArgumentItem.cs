using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists
{
    public class RetargetingListRuleArgumentItem
    {
        [JsonProperty("MembershipLifeSpan")]
        public int MembershipLifeSpan { get; set; }

        [JsonProperty("ExternalId")]
        public long ExternalId { get; set; }
    }
}
