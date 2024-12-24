using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push
{
    public enum PushTransferStatus
    {
        [Description("failed")]
        Failed = 1,
        [Description("in_progress")]
        InProgress = 2,
        [Description("pending")]
        Pending = 3,
        [Description("sent")]
        Sent = 4,
    }
}
