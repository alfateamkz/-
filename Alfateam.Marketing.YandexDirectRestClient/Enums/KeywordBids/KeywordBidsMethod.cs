using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids
{
    public enum KeywordBidsMethod
    {
        [Description("get")]
        Get = 1,
        [Description("set")]
        Set = 2,
        [Description("setAuto")]
        SetAuto = 3,
    }
}
