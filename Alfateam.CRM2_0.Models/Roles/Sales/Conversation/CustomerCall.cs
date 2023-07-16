using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Conversation
{
    /// <summary>
    /// Модель созвона с клиентом
    /// </summary>
    public class CustomerCall : AbsModel
    {

        public Customer Customer { get; set; }


        public string Phone { get; set; }
        public CustomerCallStatus Status { get; set; } = CustomerCallStatus.Planned;


        /// <summary>
        /// Заказы, которые планируются обсуждаться на встрече
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();


        public DateTime PlannedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }


        public string? Comment { get; set; }
        public string? CallRecordPath { get; set; }
    }
}
