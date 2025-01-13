using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets
{
    public enum WebpageConditionOperandEnum
    {
        [Description("DOMAIN")]
        Domain = 1,
        [Description("OFFERS_LIST_URL")]
        OffersListURL = 2,
        [Description("PAGE_CONTENT")]
        PageContent = 3,
        [Description("PAGE_TITLE")]
        PageTitle = 4,
        [Description("URL")]
        URL = 5,
    }
}
