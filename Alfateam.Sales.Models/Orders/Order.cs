using Alfateam.Core;
using Alfateam.Sales.Models.Customers;
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
        public PersonContact? PersonContact { get; set; }
		public int? PersonContactId { get; set; }



        public Company? Company { get; set; }
        public int? CompanyId { get; set; }




        public string Title { get; set; }
        public string? Description { get; set; }
        public CurrencyAndValue Sum { get; set; }





        public OrderSaleInfo SaleInfo { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
