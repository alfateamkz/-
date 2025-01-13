using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum AdGroupStatusEnum
    {
        [Description("ACCEPTED")]
        Accepted = 1,
        [Description("DRAFT")]
        Draft = 2,
        [Description("MODERATION")]
        Moderation = 3,
        [Description("PREACCEPTED")]
        PreAccepted = 4,
        [Description("REJECTED")]
        Rejected = 5,
    }
}
