using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters.Items.Orders
{
    public class OrderStatusItem : AbsModel
    {
        public OrderStatus Status { get; set; }
    }
}
