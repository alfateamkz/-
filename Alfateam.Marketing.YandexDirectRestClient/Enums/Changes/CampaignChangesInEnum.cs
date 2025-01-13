using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Changes
{
    public enum CampaignChangesInEnum
    {
        [Description("SELF")]
        Self = 1,
        [Description("CHILDREN")]
        Children = 2,
        [Description("STAT")]
        Stat = 3,
    }
}
