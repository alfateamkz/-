using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum BidModifierFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("CampaignId")]
        CampaignId = 2,
        [Description("AdGroupId")]
        AdGroupId = 3,
        [Description("Level")]
        Level = 4,
        [Description("Type")]
        Type = 5,
    }
}
