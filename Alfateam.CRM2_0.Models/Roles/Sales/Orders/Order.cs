using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Communication.Messenger.Chats;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class Order : AbsModel
    {
        public Customer Customer { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }



        public OrderStatus Status { get; set; } = OrderStatus.Lead;
        public OrderSaleInfo SaleInfo { get; set; }




        /// <summary>
        /// Путь к ТЗ
        /// </summary>
        public string? TSPath { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }


        public User ProjectManager { get; set; }
        public User? TechLead { get; set; }
        public User? TeamLead { get; set; }

        /// <summary>
        /// Чат разработки
        /// Создается, когда заказ отправляется в работу после подписания договора
        /// </summary>
        public GroupChat? Chat { get; set; }



        public List<OrderMilestone> Milestones { get; set; } = new List<OrderMilestone>();



		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int SalesDepartmentId { get; set; }

	}
}
