using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists
{
    public enum RetargetingListFieldEnum
    {
        [Description("Type")]
        Type = 1,
        [Description("Id")]
        Id = 2,
        [Description("Name")]
        Name = 3,
        [Description("Description")]
        Description = 4,
        [Description("Rules")]
        Rules = 5,
        [Description("IsAvailable")]
        IsAvailable = 6,
        [Description("Scope")]
        Scope = 7,
        [Description("AvailableForTargetsInAdGroupTypes")]
        AvailableForTargetsInAdGroupTypes = 8,
    }
}
