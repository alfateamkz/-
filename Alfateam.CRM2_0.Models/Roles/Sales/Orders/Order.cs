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
		public int CustomerId { get; set; }


		public string Title { get; set; }
        public string Description { get; set; }

        public Currency Currency { get; set; }
		public int CurrencyId { get; set; }


		public OrderStatus Status { get; set; } = OrderStatus.Lead;
        public OrderSaleInfo SaleInfo { get; set; }




        /// <summary>
        /// Путь к ТЗ
        /// </summary>
        public string? TSPath { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }


        public User? ProjectManager { get; set; }
		public int? ProjectManagerId { get; set; }

		public User? TechLead { get; set; }
		public int? TechLeadId { get; set; }


		public User? TeamLead { get; set; }
		public int? TeamLeadId { get; set; }


		/// <summary>
		/// Все рабочие, участвующие в заказе
		/// ProjectManager, TechLead и TeamLead не входят в данный список
		/// Метод GetAllParticipants() поможет получить всех, включая ProjectManager, TechLead и TeamLead
		/// </summary>
		public List<User> Employees { get; set; } = new List<User>();




		/// <summary>
		/// Чаты по заказу (разработки, обсуждение заказа и т.д.)
		/// </summary>
		public List<GroupChat> Chats { get; set; } = new List<GroupChat>();


		public List<OrderMilestone> Milestones { get; set; } = new List<OrderMilestone>();



		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int SalesDepartmentId { get; set; }


		public List<User> GetAllParticipants()
		{
			var participants = new List<User>();

			participants.AddRange(Employees);

			if (ProjectManager != null) participants.Add(ProjectManager);
			if (TeamLead != null) participants.Add(TeamLead);
			if (TechLead != null) participants.Add(TechLead);

			if (ProjectManager == null && ProjectManagerId != null) throw new Exception("Need to include ProjectManager");
			if (TeamLead == null && TeamLeadId != null) throw new Exception("Need to include TeamLead");
			if (TechLead == null && TechLeadId != null) throw new Exception("Need to include TechLead");

			return participants;
		}

	}
}
