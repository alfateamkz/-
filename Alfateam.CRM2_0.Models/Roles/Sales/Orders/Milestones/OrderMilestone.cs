using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones
{
    /// <summary>
    /// Модель этапа заказа
    /// </summary>
    public class OrderMilestone : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }


        public OrderMilestoneStatus Status { get; set; } = OrderMilestoneStatus.NotStarted;
        public List<OrderTask> Tasks { get; set; } = new List<OrderTask>();


        public List<User> Employees { get; set; } = new List<User>();
        public List<OrderMilestoneBudgetItem> BudgetItems { get; set; } = new List<OrderMilestoneBudgetItem>();

        


        public List<OrderMilestoneReport> Reports { get; set; } = new List<OrderMilestoneReport>();
        public List<OrderMilestoneDeadlineInfo> DeadlineInfos { get; set; } = new List<OrderMilestoneDeadlineInfo>();

       



    }
}
