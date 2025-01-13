using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum ClientSettingAddEnum
    {
        [Description("CORRECT_TYPOS_AUTOMATICALLY")]
        CorrectTyposAutomatically = 1,
        [Description("DISPLAY_STORE_RATING")]
        DisplayStoreRatings = 2,
    }
}
