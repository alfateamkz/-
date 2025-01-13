using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdVideos
{
    public enum AdVideoStatus
    {
        [Description("READY")]
        Ready = 1,
        [Description("ERROR")]
        Error = 2,
        [Description("CONVERTING")]
        Converting = 3,
        [Description("NEW")]
        New = 4,
    }
}
