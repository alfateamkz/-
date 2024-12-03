using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.SalesGenerators
{
    public class RepeatOrdersSalesGenerator : SalesGenerator
    {
        public bool AlwaysSetResponsibleWhoWorkingNow { get; set; }
        public bool AlwaysCreateOrder { get; set; }
        public bool AssignOldManagerToCustomer { get; set; }
        public SGCreateOrderFromOldOrder CreateOrderFromOldOrder { get; set; }


        public int? CRM_SalesFunnelId { get; set; }
    }
}
