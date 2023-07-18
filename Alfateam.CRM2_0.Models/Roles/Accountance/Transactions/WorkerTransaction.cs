using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions
{
    /// <summary>
    /// Транзакция с привязкой к работнику/контрагенту
    /// </summary>
    public class WorkerTransaction : Transaction
    {
        public Worker Worker { get; set; }
        public WorkerTransactionType Type { get; set; } = WorkerTransactionType.ProjectFee;


        /// <summary>
        /// В рамках какого проекта мы рассчитывается с работником
        /// </summary>
        public Order? Order { get; set; }
        /// <summary>
        /// В рамках какого этапа мы рассчитывается с работником
        /// </summary>
        public OrderMilestone? Milestone { get; set; }
    }
}
