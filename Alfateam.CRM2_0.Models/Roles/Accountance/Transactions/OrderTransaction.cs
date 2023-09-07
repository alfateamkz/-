using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions
{
    /// <summary>
    /// Транзакция с привязкой к заказу
    /// </summary>
    public class OrderTransaction : Transaction
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
