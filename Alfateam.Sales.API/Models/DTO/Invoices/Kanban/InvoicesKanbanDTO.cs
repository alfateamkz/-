using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices.Kanban
{
    public class InvoicesKanbanDTO : DTOModelAbs<InvoicesKanban>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [ForClientOnly]
        public List<InvoicesKanbanStageDTO> Stages { get; set; } = new List<InvoicesKanbanStageDTO>();
    }
}
