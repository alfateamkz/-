using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds
{
    public enum FeedStatusEnum
    {
        [Description("NEW")]
        New = 1,
        [Description("UPDATING")]
        Updating = 2,
        [Description("DONE")]
        Done = 3,
        [Description("ERROR")]
        Error = 4,
    }
}
