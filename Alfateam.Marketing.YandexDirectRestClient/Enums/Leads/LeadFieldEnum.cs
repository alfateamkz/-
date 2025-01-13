using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Leads
{
    public enum LeadFieldEnum
    {
        [Description("SubmittedAt")]
        SubmittedAt = 1,
        [Description("TurboPageId")]
        TurboPageId = 2,
        [Description("TurboPageName")]
        TurboPageName = 3,
        [Description("Id")]
        Id = 4,
        [Description("Data")]
        Data = 5,
    }
}
