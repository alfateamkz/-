using Alfateam.Marketing.Models.Filters.Items.Leads;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Leads
{
    public class LeadKanbanStatusItemDTO : DTOModelAbs<LeadKanbanStatusItem>
    {
        public int CRM_KanbanId { get; set; }
        public int CRM_KanbanStageId { get; set; }
    }
}
