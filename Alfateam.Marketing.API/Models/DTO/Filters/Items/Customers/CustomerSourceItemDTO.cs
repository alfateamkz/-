using Alfateam.Marketing.Models.Enums.Leads;
using Alfateam.Marketing.Models.Filters.Items.Customers;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Customers
{
    public class CustomerSourceItemDTO : DTOModelAbs<CustomerSourceItem>
    {
        public LeadSource Source { get; set; }
    }
}
