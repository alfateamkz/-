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
    /// Модель оффлайн встречи с клиентом
    /// </summary>
    public class CustomerMeeting : AbsModel
    {
        /// <summary>
        /// Клиент, с которым назначена встреча
        /// </summary>
        public Customer Customer { get; set; }
		public int CustomerId { get; set; }


		/// <summary>
		/// Адрес встречи с клиентом
		/// </summary>
		public Address Address { get; set; }


        /// <summary>
        /// Статус встречи с клиентом
        /// </summary>
        public CustomerMeetingStatus Status { get; set; } = CustomerMeetingStatus.Planned;



        /// <summary>
        /// Заказы, которые планируются обсуждаться на встрече
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();




        /// <summary>
        /// Запланированная дата
        /// </summary>
        public DateTime PlannedAt { get; set; }
        /// <summary>
        /// Дата фактического начала встречи
        /// </summary>
        public DateTime? StartedAt { get; set; }
        /// <summary>
        /// Дата завершения встречи
        /// </summary>
        public DateTime? EndedAt { get; set; }


        /// <summary>
        /// Комментарий касательно встречи
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Дополнительные вложения(файлы) касательно встречи
        /// </summary>
        public List<CustomerMeetingAttachment> Attachments { get; set; } = new List<CustomerMeetingAttachment>();
    }
}
