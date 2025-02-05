using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban
{
    public class BusinessProposalsKanbanDataDTO : DTOModelAbs<BusinessProposalsKanbanData>
    {
        [ForClientOnly]
        public BusinessProposalsKanbanDTO Kanban { get; set; }
        [ForClientOnly]
        public BusinessProposalsKanbanStageDTO Stage { get; set; }
    }
}
