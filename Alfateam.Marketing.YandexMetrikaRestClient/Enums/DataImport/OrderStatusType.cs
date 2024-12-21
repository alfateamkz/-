using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum OrderStatusType
    {
        [Description("IN_PROGRESS")]
        InProgress = 1,
        [Description("PAID")]
        Paid = 2,
        [Description("CANCELLED")]
        Cancelled = 3,
        [Description("SPAM")]
        Spam = 4,
        [Description("OTHER")]
        Other = 5
    }
}
