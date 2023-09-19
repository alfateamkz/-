using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Orders
{
	public class OrderClientModel : ClientModel<Order>
	{
		public CustomerClientModel Customer { get; set; }


		public string Title { get; set; }
		public string Description { get; set; }
		public CurrencyClientModel Currency { get; set; }



		public OrderStatus Status { get; set; }
		public OrderSaleInfoClientModel SaleInfo { get; set; }




		/// <summary>
		/// Путь к ТЗ
		/// </summary>
		public string? TSPath { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime Deadline { get; set; }


		public UserClientModel ProjectManager { get; set; }
		public UserClientModel? TechLead { get; set; }
		public UserClientModel? TeamLead { get; set; }
	}
}
