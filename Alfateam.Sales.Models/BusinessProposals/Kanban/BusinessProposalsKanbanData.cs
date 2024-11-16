using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.BusinessProposals.Kanban
{
    public class BusinessProposalsKanbanData : AbsModel
    {
        public BusinessProposalsKanban Kanban { get; set; }
        public int KanbanId { get; set; }


        public BusinessProposalsKanbanStage Stage { get; set; }
        public int StageId { get; set; }
    }
}
