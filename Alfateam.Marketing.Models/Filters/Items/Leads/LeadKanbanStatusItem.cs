using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters.Items.Leads
{
    public class LeadKanbanStatusItem : AbsModel
    {
        public int CRM_KanbanId { get; set; }
        public int CRM_KanbanStageId { get; set; }
    }
}
