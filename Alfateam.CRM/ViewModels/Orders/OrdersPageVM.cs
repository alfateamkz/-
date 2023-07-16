using Alfateam.Database.Models.CRM.Orders;

namespace Alfateam.CRM.ViewModels.Orders {
    public class OrdersPageVM {
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
