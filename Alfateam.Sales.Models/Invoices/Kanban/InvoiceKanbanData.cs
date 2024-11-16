using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.Kanban
{
    public class InvoiceKanbanData : AbsModel
    {
        public InvoicesKanban Kanban { get; set; }
        public int KanbanId { get; set; }


        public InvoicesKanbanStage Stage { get; set; }
        public int StageId { get; set; }
    }
}
