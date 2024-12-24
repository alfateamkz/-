using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds
{
    public enum FeedType
    {
        [Description("REALTY")]
        Realty = 1,
        [Description("VACANCY")]
        Vacancy = 2,
        [Description("GOODS")]
        Goods = 3,
        [Description("DOCTORS")]
        Doctors = 4,
        [Description("CARS")]
        Cars = 5,
        [Description("SERVICES")]
        Services = 6,
        [Description("EDUCATION")]
        Education = 7,
        [Description("ACTIVITY")]
        Activity = 8
    }
}
