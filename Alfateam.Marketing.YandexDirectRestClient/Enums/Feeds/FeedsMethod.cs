using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds
{
    public enum FeedsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("delete")]
        Delete = 2,
        [Description("get")]
        Get = 3,
        [Description("update")]
        Update = 4,
    }
}
