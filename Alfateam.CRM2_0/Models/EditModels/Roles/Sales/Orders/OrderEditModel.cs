using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Orders
{
	public class OrderEditModel : EditModel<Order>
	{
		public int CustomerId { get; set; }


		public string Title { get; set; }
		public string Description { get; set; }


		public int CurrencyId { get; set; }


		public OrderStatus Status { get; set; }
		public OrderSaleInfoEditModel SaleInfo { get; set; }




		public DateTime StartDate { get; set; }
		public DateTime Deadline { get; set; }
	}
}
