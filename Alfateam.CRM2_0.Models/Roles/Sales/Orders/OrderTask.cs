using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders
{
    /// <summary>
    /// Модель задачи по заказу
    /// </summary>
    public class OrderTask : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public OrderTaskStatus Status { get; set; } = OrderTaskStatus.NotStarted;


        /// <summary>
        /// Подзадачи
        /// </summary>
        public List<OrderTask> SubTasks { get; set; } = new List<OrderTask>();

    }
}
