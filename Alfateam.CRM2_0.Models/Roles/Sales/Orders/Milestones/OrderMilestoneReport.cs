using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones
{
    /// <summary>
    /// Модель отчета по этапу заказа
    /// </summary>
    public class OrderMilestoneReport : AbsModel
    {
        public User CreatedBy { get; set; }
        public List<OrderMilestoneReportItem> Items { get; set; } = new List<OrderMilestoneReportItem>();

        
    }
}
