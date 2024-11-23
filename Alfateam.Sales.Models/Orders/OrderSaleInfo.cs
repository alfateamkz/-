using Alfateam.Core;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Orders
{
    /// <summary>
    /// Продажная информация о заказе
    /// </summary>
    public class OrderSaleInfo : AbsModel
    {
        public SalesFunnel Funnel { get; set; }
        public int FunnelId { get; set; }


        public SalesFunnelStage FunnelStage { get; set; }
        public int FunnelStageId { get; set; }



        /// <summary>
        /// Продажник, который внес заказ в систему
        /// </summary>
        public User FoundBy { get; set; }
		public int FoundById { get; set; }



        /// <summary>
        /// Продажник, который ответственнен за заказ
        /// </summary>
        public User Responsible { get; set; }
        public int ResponsibleId { get; set; }
    }
}
