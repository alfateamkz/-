using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets
{
    public enum NegativeKeywordSharedSetFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Name")]
        Name = 2,
        [Description("NegativeKeywords")]
        NegativeKeywords = 3,
        [Description("Associated")]
        Associated = 4,
    }
}
