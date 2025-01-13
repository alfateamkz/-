using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Changes
{
    public enum ChangesCheckFieldNamesEnum
    {
        [Description("CampaignIds")]
        CampaignIds = 1,
        [Description("AdGroupIds")]
        AdGroupIds = 2,
        [Description("AdIds")]
        AdIds = 3,
        [Description("CampaignsStat")]
        CampaignsStat = 4,
    }
}
