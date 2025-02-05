using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban
{
    public class BusinessProposalsKanbanStageDTO : DTOModelAbs<BusinessProposalsKanbanStage>
    {
        public string Title { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }



        [ForClientOnly]
        public BPKanbanStageStatus Status { get; set; }

        [ForClientOnly]
        public bool IsSystemStage { get; set; }

        [ForClientOnly]
        public int Order { get; set; }
    }
}
