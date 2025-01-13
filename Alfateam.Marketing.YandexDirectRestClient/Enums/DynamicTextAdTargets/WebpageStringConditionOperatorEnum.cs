using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets
{
    public enum WebpageStringConditionOperatorEnum
    {
        [Description("EQUALS_ANY")]
        EqualsAny = 1,
        [Description("NOT_EQUALS_ALL")]
        NotEqualsAll = 2,
        [Description("CONTAINS_ANY")]
        ContainsAny = 3,
        [Description("NOT_CONTAINS_ALL")]
        NotContainsAll = 4,
    }
}
