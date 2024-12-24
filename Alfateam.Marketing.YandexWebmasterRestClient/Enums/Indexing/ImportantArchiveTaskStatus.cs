using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing
{
    public enum ImportantArchiveTaskStatus
    {
        [Description("IN_PROGRESS")]
        IN_PROGRESS = 1,
        [Description("DONE")]
        DONE = 2,
        [Description("FAILED")]
        FAILED = 3,
    }
}
