using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum PagePickupOptionEnum
    {
        [Description("CURBSIDE")]
        CurbSide = 1,
        [Description("IN_STORE")]
        InStore = 2,



        [Description("OTHER")]
        Other = 999,
    }
}
