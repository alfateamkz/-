using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Orders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices
{

    public class Invoice : AbsModel
    {
        public string UniqueURL { get; set; } = $"{DateTime.UtcNow.ToString("dd-MM-yyyy")}-{System.Guid.NewGuid().ToString()}";


        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        public Order Order { get; set; }
        public int OrderId { get; set; }



        public string Title { get; set; }
        public string HTMLContent { get; set; }



        public string CurrencyCode { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();



        /// <summary>
        /// Не равно null, если счет на оплату оплачен
        /// </summary>
        public InvoicePaidInfo? PaidInfo { get; set; }

    }
}
