using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{
    public class CustomerConversation : AbsModel
    {
        public int CustomerId { get; set; }
        public CustomerCommunicationStatus Status { get; set; } = CustomerCommunicationStatus.Planned;



        public DateTime PlannedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }



        /// <summary>
        /// Заказы, которые планируются обсуждаться на встрече
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();



        public string? Comment { get; set; }
        public string? CommunicationRecordPath { get; set; }
    }
}
