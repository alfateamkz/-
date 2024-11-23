using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.API.Models.DTO.Invoices.Kanban;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Invoices
{
    public class InvoiceDTO : DTOModelAbs<Invoice>
    {
        [ForClientOnly]
        public string UniqueURL { get; set; }




        [ForClientOnly]
        public PersonContactDTO? PersonContact { get; set; }

        [HiddenFromClient]
        public int? PersonContactId { get; set; }



        [ForClientOnly]
        public CompanyDTO? Company { get; set; }

        [HiddenFromClient]
        public int? CompanyId { get; set; }



        [ForClientOnly]
        public OrderDTO? Order { get; set; }
        [HiddenFromClient]
        public int? OrderId { get; set; }



        public string Title { get; set; }
        public string? HTMLContent { get; set; }




        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        [HiddenFromClient]
        public int CurrencyId { get; set; }

        public List<InvoiceItemDTO> Items { get; set; } = new List<InvoiceItemDTO>();



        public DateTime? NeedToPayBefore { get; set; }






        [ForClientOnly]
        [Description("Не равно null, если счет на оплату оплачен")]
        public InvoicePaidInfoDTO? PaidInfo { get; set; }

        [ForClientOnly]
        [Description("Не равно null, если счет на оплату отклонен клиентом или менеджером")]
        public InvoiceRejectedInfoDTO? RejectedInfo { get; set; }


        [ForClientOnly]
        public InvoiceKanbanDataDTO KanbanData { get; set; }


        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }
    }
}
