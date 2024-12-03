using Alfateam.Core;
using Alfateam.Marketing.Models.Enums.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters.Items.Leads
{
    public class LeadStatusItem : AbsModel
    {
        public LeadStatus Status { get; set; }
    }
}
