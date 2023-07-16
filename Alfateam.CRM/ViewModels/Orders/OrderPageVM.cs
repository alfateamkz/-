using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Orders;
using Alfateam.Database.Models.CRM.Sales;

namespace Alfateam.CRM.ViewModels.Orders {
    public class OrderPageVM {
        public OrderModel Order { get; set; } = new OrderModel();


        public List<Client> Clients { get; set; } = new List<Client>();


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Resource> Resources { get; set; } = new List<Resource>();
    }
}
