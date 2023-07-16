using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones
{
    /// <summary>
    /// Модель пункта бюджета этапа заказа
    /// </summary>
    public class OrderMilestoneBudgetItem : AbsModel
    {
        public string Title { get; set; }
        public double Sum { get; set; }
    }
}
