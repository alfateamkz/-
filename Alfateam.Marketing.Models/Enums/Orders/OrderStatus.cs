using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums.Orders
{
    public enum OrderStatus
    {
        NewOrder = 1,
        InWork = 2,


        OrderLost = 8,
        OrderClosed = 9
    }
}
