using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices.Kanban
{
    public class InvoiceKanbanDataDTO : DTOModelAbs<InvoiceKanbanData>
    {
        [ForClientOnly]
        public InvoicesKanbanDTO Kanban { get; set; }
        [ForClientOnly]
        public InvoicesKanbanStageDTO Stage { get; set; }
    }
}
