using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Orders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices
{

    public class Invoice : AbsModel
    {
        public string UniqueURL { get; set; } = $"{DateTime.UtcNow.ToString("dd-MM-yyyy")}-{System.Guid.NewGuid().ToString()}";

        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }



        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


        public Order Order { get; set; }
        public int OrderId { get; set; }



        public string Title { get; set; }
        public string HTMLContent { get; set; }



        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();



        [NotMapped]
        public double TotalSum => Items.Sum(o => o.TotalPrice);




        public DateTime? NeedToPayBefore { get; set; }
        [NotMapped]
        public bool IsOverdue => NeedToPayBefore != null && NeedToPayBefore < DateTime.UtcNow;


        /// <summary>
        /// Не равно null, если счет на оплату оплачен
        /// </summary>
        public InvoicePaidInfo? PaidInfo { get; set; }
        public int? PaidInfoId { get; set; }





        /// <summary>
        /// Не равно null, если счет на оплату отклонен клиентом или менеджером
        /// </summary>
        public InvoiceRejectedInfo? RejectedInfo { get; set; }
        public int? RejectedInfoId { get; set; }



        /// <summary>
        /// Информация о канбане, в котором находится счет на оплату, если не равно null
        /// </summary>
        public InvoiceKanbanData? KanbanData { get; set; }
        public int? KanbanDataId { get; set; }
    }
}
