using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum ShippingWeightUnit
    {
        [Description("g")]
        G = 1,
        [Description("kg")]
        Kg = 2,
        [Description("oz")]
        Oz = 3,
        [Description("lb")]
        Lb = 4,
    }
}
