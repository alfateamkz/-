﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Invoices.Kanban
{
    public class InvoicesKanbanStageDTO : DTOModelAbs<InvoicesKanbanStage>
    {
        public string Title { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }

        [ForClientOnly]
        public InvoiceKanbanStageStatus Status { get; set; }

        [ForClientOnly]
        public bool IsSystemStage { get; set; }

        [ForClientOnly]
        public int Order { get; set; }
    }
}
