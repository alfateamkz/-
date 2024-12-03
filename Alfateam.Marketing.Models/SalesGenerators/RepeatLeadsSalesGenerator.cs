using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators.Items;
using Alfateam.Marketing.Models.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.SalesGenerators
{
    public class RepeatLeadsSalesGenerator : SalesGenerator
    {
        public bool AlwaysSetResponsibleWhoWorkingNow { get; set; }
        public bool AlwaysCreateLead { get; set; }
        public bool AssignOldManagerToLead { get; set; }
    }
}
