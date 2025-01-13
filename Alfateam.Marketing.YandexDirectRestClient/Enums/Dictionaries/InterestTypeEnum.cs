using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum InterestTypeEnum
    {
        [Description("SHORT_TERM")]
        ShortTerm = 1,
        [Description("LONG_TERM")]
        LongTerm = 2,
        [Description("ANY")]
        Any = 3,
    }
}
