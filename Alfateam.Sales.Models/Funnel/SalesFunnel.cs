using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Funnel
{
    /// <summary>
    /// Модель воронки продаж
    /// </summary>
    public class SalesFunnel : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<SalesFunnelStage> Stages { get; set; } = new List<SalesFunnelStage>();




        public SalesFunnelStage InsertStage(int afterStageId, SalesFunnelStage stage)
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
