using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Leads.Kanban
{
    public class LeadsKanbanData : AbsModel
    {
        public LeadsKanban Kanban { get; set; }
        public int KanbanId { get; set; }


        public LeadsKanbanStage Stage { get; set; }
        public int StageId { get; set; }
    }
}
