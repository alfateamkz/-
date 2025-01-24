using Alfateam.ID.Models.DTO;

namespace Alfateam.AdminPanelGeneral.API.Models.Customers
{
    public class CustomerWithProducts
    {
        public UserDTO User { get; set; }
        public List<CustomerProduct> Products { get; set; } = new List<CustomerProduct>();
    }
}
