using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Leads.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Leads.Kanban
{
    public class LeadsKanbanStageDTO : DTOModelAbs<LeadsKanbanStage>
    {
        public string Title { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }


        [ForClientOnly]
        public LeadsKanbanStageStatus Status { get; set; }
        [ForClientOnly]
        public bool IsSystemStage { get; set; }
        [ForClientOnly]
        public int Order { get; set; }
    }
}
