using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices.Kanban
{
    public class InvoicesKanban : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<InvoicesKanbanStage> Stages { get; set; } = new List<InvoicesKanbanStage>();





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
