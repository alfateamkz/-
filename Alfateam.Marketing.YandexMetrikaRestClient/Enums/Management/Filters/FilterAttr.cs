using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Filters
{
    public enum FilterAttr
    {
        [Description("title")]
        Title = 1,
        [Description("client_ip")]
        ClientIP = 2,
        [Description("url")]
        URL = 3,
        [Description("referer")]
        Referer = 4,
        [Description("uniq_id")]
        UniqId = 5
    }
}
