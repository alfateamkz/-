using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Conversation
{
    /// <summary>
    /// Модель оффлайн встречи с клиентом
    /// </summary>
    public class CustomerMeeting : CustomerConversation
    {

		/// <summary>
		/// Адрес встречи с клиентом
		/// </summary>
		public string Address { get; set; }

        /// <summary>
        /// Дополнительные вложения(файлы) касательно встречи
        /// </summary>
        public List<CustomerMeetingAttachment> Attachments { get; set; } = new List<CustomerMeetingAttachment>();
    }
}
