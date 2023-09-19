using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Conversation
{
    /// <summary>
    /// Модель конференции с клиентом
    /// </summary>
    public class CustomerConference : AbsModel
    {
        public Customer Customer { get; set; }
		public int CustomerId { get; set; }


		public CustomerConferenceStatus Status { get; set; } = CustomerConferenceStatus.Planned;


        /// <summary>
        /// Заказы, которые планируются обсуждаться на встрече
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();


        /// <summary>
        /// Пользователи CRM, которые могут подключиться к конференции
        /// Обязательно должны быть членами конференции директор, топ-менеджер, продажник и сам клиент
        /// Остальные по усмотрению
        /// </summary>
        public List<User> Members { get; set; } = new List<User>();



        public DateTime PlannedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }


        public string? Comment { get; set; }
        public string? ConferenceRecordPath { get; set; }
    }
}
