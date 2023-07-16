using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones
{
    /// <summary>
    /// Модель пункта отчета по этапу заказа
    /// </summary>
    public class OrderMilestoneReportItem : AbsModel
    {
        public OrderTask Task { get; set; }
        public string Comment { get; set; }

        public List<OrderMilestoneReportItemAttachment> Attachments { get; set; } = new List<OrderMilestoneReportItemAttachment>();
    }
}
