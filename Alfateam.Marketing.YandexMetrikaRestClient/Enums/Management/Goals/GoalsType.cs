using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals
{
    public enum GoalsType
    {
        [Description("url")]
        URL = 1,
        [Description("number")]
        Number = 2,
        [Description("step")]
        Step = 3,
        [Description("action")]
        Action = 4,
        [Description("phone")]
        Phone = 5,
        [Description("email")]
        Email = 6,
        [Description("payment_system")]
        PaymentSystem = 7,
        [Description("messenger")]
        Messenger = 8,
        [Description("file")]
        File = 9,
        [Description("search")]
        Search = 10,
        [Description("social")]
        Social = 11,
        [Description("visit_duration")]
        VisitDuration = 12,
    }
}
