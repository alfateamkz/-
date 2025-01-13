using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum AdGroupsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("get")]
        Get = 2,
        [Description("delete")]
        Delete = 3,
        [Description("update")]
        Update = 4
    }
}
