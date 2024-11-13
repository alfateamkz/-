using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Funnel
{
    /// <summary>
    /// Туннель продаж. Можно указать, на какой этап другой воронки заказ будет отправляться
    /// </summary>
    public class SalesFunnelTunnel : AbsModel
    {
        public SalesFunnelTunnelActionType Type { get; set; }




        public SalesFunnelStage FromFunnelStage { get; set; }
        public int FromFunnelStageId { get; set; }



        public SalesFunnelStage ToFunnelStage { get; set; }
        public int ToFunnelStageId { get; set; }
    }
}
