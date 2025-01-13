using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum DifferentlyOpenOfferingsEnum
    {
        [Description("ONLINE_SERVICES")]
        OnlineServices = 1,
        [Description("DELIVERY")]
        Delivery = 2,
        [Description("PICKUP")]
        Pickup = 3,



        [Description("OTHER")]
        Other = 999,
    }
}
