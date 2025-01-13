using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Changes
{
    public enum ChangesMethod
    {
        [Description("check")]
        Check = 1,
        [Description("checkCampaigns")]
        CheckCampaigns = 2,
        [Description("checkDictionaries")]
        CheckDictionaries = 3,
    }
}
