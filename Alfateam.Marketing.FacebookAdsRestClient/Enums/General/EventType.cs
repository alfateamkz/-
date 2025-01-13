using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.General
{
    public enum EventType
    {
        [Description("private")]
        Private = 1,
        [Description("public")]
        Public = 2,
        [Description("group")]
        Group = 3,
        [Description("community")]
        Community = 4,
        [Description("friends")]
        Friends = 5,
        [Description("work_company")]
        WorkCompany = 5,
    }
}
