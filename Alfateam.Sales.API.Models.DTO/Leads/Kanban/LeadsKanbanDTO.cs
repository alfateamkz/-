using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Leads.Kanban
{
    public class LeadsKanbanDTO : DTOModelAbs<LeadsKanban>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [ForClientOnly]
        public List<LeadsKanbanStageDTO> Stages { get; set; } = new List<LeadsKanbanStageDTO>();
    }
}
