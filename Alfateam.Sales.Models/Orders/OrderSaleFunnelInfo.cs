using Alfateam.Core;
using Alfateam.Sales.Models.Funnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Orders
{
    public class OrderSaleFunnelInfo : AbsModel
    {
        public SalesFunnel Funnel { get; set; }
        public int FunnelId { get; set; }


        public SalesFunnelStage FunnelStage { get; set; }
        public int FunnelStageId { get; set; }
    }
}
