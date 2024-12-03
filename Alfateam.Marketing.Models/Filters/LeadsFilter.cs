using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Marketing.Models.Filters.Items.Leads;
using Alfateam.SharedModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters
{
    public class LeadsFilter : AbsModel
    {
        public DateFilterModel? DatePeriod { get; set; }



        public List<FilterContactTypeItem> ContactTypes { get; set; } = new List<FilterContactTypeItem>();
        public List<LeadKanbanStatusItem> KanbanStatuses { get; set; } = new List<LeadKanbanStatusItem>();
        public List<LeadSourceItem> LeadSources { get; set; } = new List<LeadSourceItem>();
        public List<LeadStatusItem> LeadStatuses { get; set; } = new List<LeadStatusItem>();
    }
}
