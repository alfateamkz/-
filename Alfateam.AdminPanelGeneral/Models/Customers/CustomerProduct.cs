using Alfateam.AdminPanelGeneral.API.Enums;

namespace Alfateam.AdminPanelGeneral.API.Models.Customers
{
    public class CustomerProduct
    {
        public PublicProductName ProductName { get; set; }
        public string Domain { get; set; }


        public DateTime RegisteredAt { get; set; }
        public DateTime SubscriptionBefore { get; set; }
    }
}
