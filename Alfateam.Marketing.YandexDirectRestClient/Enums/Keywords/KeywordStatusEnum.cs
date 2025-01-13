using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum KeywordStatusEnum
    {
        [Description("ACCEPTED")]
        Accepted = 1,
        [Description("DRAFT")]
        Draft = 2,
        [Description("REJECTED")]
        Rejected = 3,



        [Description("UNKNOWN")]
        Unknown = 999
    }
}
