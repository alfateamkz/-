using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban
{
    public class BusinessProposalsKanbanDTO : DTOModelAbs<BusinessProposalsKanban>
    {
        public string Title { get; set; }
        public string? Description { get; set; }




        [ForClientOnly]
        public List<BusinessProposalsKanbanStageDTO> Stages { get; set; } = new List<BusinessProposalsKanbanStageDTO>();
    }
}
