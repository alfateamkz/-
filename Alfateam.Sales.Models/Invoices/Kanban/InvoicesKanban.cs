using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
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



        public InvoicesKanbanStage InsertStage(int afterStageId, InvoicesKanbanStage stage)
        {
            var afterStage = Stages.FirstOrDefault(o => o.Id == afterStageId);
            if (afterStage == null)
            {
                throw new Exception("Этап не найден");
            }

            foreach (var item in Stages)
            {
                item.Order++;
            }
            stage.Order = afterStage.Order + 1;

            Stages.Add(stage);
            return stage;
        }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
