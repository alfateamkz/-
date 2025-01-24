using Alfateam.ID.Models.DTO;

namespace Alfateam.AdminPanelGeneral.API.Models.Customers
{
    public class ProductCustomer
    {
        public UserDTO User { get; set; }
        public string Domain { get; set; }



        public DateTime RegisteredAt { get; set; }
        public DateTime SubscriptionBefore { get; set; }
    }
}
