using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters.Items.Orders
{
    public class SalesFunnelStageItem : AbsModel
    {
        public int CRM_FunnelId { get; set; }
        public int CRM_FunnelStageId { get; set; }
    }
}
