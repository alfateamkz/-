using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Recrawl
{
    public enum HostRecrawlTaskStatus
    {
        [Description("IN_PROGRESS")]
        InProgress = 1,
        [Description("DONE")]
        Done = 2,
        [Description("FAILED")]
        Failed = 3
    }
}
