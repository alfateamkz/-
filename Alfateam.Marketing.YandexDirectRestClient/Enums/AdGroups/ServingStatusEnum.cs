using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum ServingStatusEnum
    {
        [Description("ELIGIBLE")]
        Eligible = 1,
        [Description("RARELY_SERVED")]
        RarelyServed = 2
    }
}
