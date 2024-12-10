using Alfateam.Marketing.Models.Filters;
using Alfateam.Marketing.Models.Filters.Items.Leads;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Website.API.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Filters.Items;
using Alfateam.Marketing.API.Models.DTO.Filters.Items.Leads;

namespace Alfateam.Marketing.API.Models.DTO.Filters
{
    public class LeadsFilterDTO : DTOModelAbs<LeadsFilter>
    {
        public DateFilterModelDTO? DatePeriod { get; set; }



        public List<FilterContactTypeItemDTO> ContactTypes { get; set; } = new List<FilterContactTypeItemDTO>();
        public List<LeadKanbanStatusItemDTO> KanbanStatuses { get; set; } = new List<LeadKanbanStatusItemDTO>();
        public List<LeadSourceItemDTO> LeadSources { get; set; } = new List<LeadSourceItemDTO>();
        public List<LeadStatusItemDTO> LeadStatuses { get; set; } = new List<LeadStatusItemDTO>();
    }
}
