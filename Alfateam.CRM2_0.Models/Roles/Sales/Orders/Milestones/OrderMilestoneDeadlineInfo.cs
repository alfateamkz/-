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
    /// Модель переноса сроков по этапу
    /// </summary>
    public class OrderMilestoneDeadlineInfo : AbsModel
    {
        public DateTime OldDealine { get; set; }
        public DateTime NewDealine { get; set; }


        public DeadlineFailedReason Reason { get; set; }
        public string Comment { get; set; }
    }
}
