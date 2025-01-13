using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ClientSettingGetEnum
    {
        [Description("CORRECT_TYPOS_AUTOMATICALLY")]
        CorrectTyposAutomatically = 1,
        [Description("DISPLAY_STORE_RATING")]
        DisplayStoreRating = 2,
        [Description("SHARED_ACCOUNT_ENABLED")]
        SharedAccountEnabled = 3,
    }
}
