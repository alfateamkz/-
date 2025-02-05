using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Leads.Kanban
{
    public class LeadsKanbanDataDTO : DTOModelAbs<LeadsKanbanData>
    {
        [ForClientOnly]
        public LeadsKanbanDTO Kanban { get; set; }
        [ForClientOnly]
        public LeadsKanbanStageDTO Stage { get; set; }
    }
}
