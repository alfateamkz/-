using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.BusinessProposals.Kanban
{
    public class BusinessProposalsKanban : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<BusinessProposalsKanbanStage> Stages { get; set; } = new List<BusinessProposalsKanbanStage>();






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
