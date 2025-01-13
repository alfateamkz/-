using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum CanSelectEnum
    {
        [Description("ALL")]
        All = 1,
        [Description("EXCEPT_ALL")]
        ExceptAll = 2,
    }
}
