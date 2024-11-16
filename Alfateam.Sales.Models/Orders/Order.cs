using Alfateam.Core;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Orders
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class Order : AbsModel
    {
        public Customer Customer { get; set; }
		public int CustomerId { get; set; }


		public string Title { get; set; }
        public string Description { get; set; }



        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public double Sum { get; set; }




		public OrderStatus Status { get; set; }
        public int StatusId { get; set; }


        public OrderSaleInfo SaleInfo { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
