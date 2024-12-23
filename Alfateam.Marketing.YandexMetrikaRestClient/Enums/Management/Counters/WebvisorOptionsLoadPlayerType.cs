using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters
{
    public enum WebvisorOptionsLoadPlayerType
    {
        [Description("proxy")]
        Proxy = 1,
        [Description("on_your_behalf")]
        OnYourBehalf =2,
    }
}
