using Alfateam.Marketing.Models.Enums.Leads;
using Alfateam.Marketing.Models.Filters.Items.Leads;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Leads
{
    public class LeadSourceItemDTO : DTOModelAbs<LeadSourceItem>
    {
        public LeadSource Source { get; set; }
    }
}
