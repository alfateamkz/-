using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.Models.Orders;

namespace Alfateam.Sales.API.Models
{
    public class LeadTransformationModel
    {
        public int LeadId { get; set; }


        public OrderDTO? NewOrder { get; set; }
        public PersonContactDTO? NewPersonContact { get; set; }
        public CompanyDTO? NewCompany { get; set; }
    }
}
