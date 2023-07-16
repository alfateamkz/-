using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Orders;
using Alfateam.Database.Models.CRM.Sales;

namespace Alfateam.CRM.ViewModels.Orders {
    public class OrderStagePageVM {

        public OrderStage Stage { get; set; } = new OrderStage();


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Resource> Resources { get; set; } = new List<Resource>();
    }
}
