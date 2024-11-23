using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums.Statuses
{
    public enum LeadsKanbanStageStatus
    {
        NewLead = 1,
        InWork = 2,
        
        RejectedLead = 8,
        ConvertedLead = 9
    }
}
