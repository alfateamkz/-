using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds
{
    public enum UrlFeedFieldEnum
    {
        [Description("Login")]
        Login = 1,
        [Description("Url")]
        URL = 2,
        [Description("RemoveUtmTags")]
        RemoveUTMTags = 2,
    }
}
