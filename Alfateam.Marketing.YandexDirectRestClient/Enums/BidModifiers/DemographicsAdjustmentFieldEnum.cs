using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum DemographicsAdjustmentFieldEnum
    {
        [Description("Gender")]
        Gender = 1,
        [Description("Age")]
        Age = 2,
        [Description("BidModifier")]
        BidModifier = 3,
        [Description("Enabled")]
        Enabled = 4,
    }
}
