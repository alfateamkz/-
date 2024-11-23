using Alfateam.Core;
using Alfateam.Sales.Models.Enums.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Leads.Kanban
{
    public class LeadsKanbanStage : AbsModel
    {
        public string Title { get; set; }
        public string BGHexColor { get; set; }
        public string TextHexColor { get; set; }


        public LeadsKanbanStageStatus Status { get; set; }
        public bool IsSystemStage { get; set; }
        public int Order { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LeadsKanbanId { get; set; }
    }
}
