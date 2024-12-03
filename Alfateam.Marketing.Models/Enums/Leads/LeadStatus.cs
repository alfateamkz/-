using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums.Leads
{
    public enum LeadStatus
    {
        NewLead = 1,
        InWork = 2,

        RejectedLead = 8,
        ConvertedLead = 9
    }
}
