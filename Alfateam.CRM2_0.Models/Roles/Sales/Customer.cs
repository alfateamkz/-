using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales
{
    /// <summary>
    /// Модель клиента
    /// </summary>
    public class Customer : User
    {
        /// <summary>
        /// Юридическая форма
        /// Если Company != null, то формы компании и клиента должны совпадать
        /// </summary>
        public LegalForm Form { get; set; }
        public Company? Company { get; set; }



        /// <summary>
        /// История оффлайн встреч с клиентом
        /// </summary>
        public List<CustomerMeeting> Meetings { get; set; } = new List<CustomerMeeting>();

        /// <summary>
        /// История созвонов с клиентом
        /// </summary>
        public List<CustomerCall> Calls { get; set; } = new List<CustomerCall>();
        /// <summary>
        /// История конференций с клиентом
        /// </summary>
        public List<CustomerConference> Conferences { get; set; } = new List<CustomerConference>();



        /// <summary>
        /// Продажник, который привлек данного клиента 
        /// </summary>
        public User FoundBy { get; set; }
		public int FoundById { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesDepartmentId { get; set; }
	}
}
