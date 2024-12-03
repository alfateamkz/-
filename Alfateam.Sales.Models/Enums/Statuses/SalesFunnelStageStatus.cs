using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums.Statuses
{
    public enum SalesFunnelStageStatus
    {
        NewOrder = 1,
        InWork = 2,


        OrderLost = 8,
        OrderClosed = 9
    }
}
