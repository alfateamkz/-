using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Funnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders
{
    /// <summary>
    /// Продажная информация о заказе
    /// </summary>
    public class OrderSaleInfo : AbsModel
    {
        public SalesFunnel? Funnel { get; set; }
		public int? FunnelId { get; set; }


		public SalesFunnelStage? FunnelStage { get; set; }
		public int? FunnelStageId { get; set; }




		/// <summary>
		/// Продажник, который внес заказ в систему
		/// </summary>
		public User FoundBy { get; set; }
		public int FoundById { get; set; }
	}
}
