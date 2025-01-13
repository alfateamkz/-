using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Ads
{
    public enum AdsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("get")]
        Get = 2,
        [Description("delete")]
        Delete = 3,
        [Description("archive")]
        Archive = 4,
        [Description("moderate")]
        Moderate = 5,
        [Description("resume")]
        Resume = 6,
        [Description("suspend")]
        Suspend = 7,
        [Description("unarchive")]
        Unarchive = 8,
        [Description("update")]
        Update = 9,
    }
}
