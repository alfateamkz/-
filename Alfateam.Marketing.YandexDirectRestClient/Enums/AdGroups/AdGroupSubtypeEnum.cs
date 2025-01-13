using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum AdGroupSubtypeEnum
    {
        [Description("WEBPAGE")]
        WebPage = 1,
        [Description("FEED")]
        Feed = 2,
        [Description("NONE")]
        None = 3,
        [Description("KEYWORDS")]
        Keywords = 4,
        [Description("USER_PROFILE")]
        UserProfile = 5,
    }
}
