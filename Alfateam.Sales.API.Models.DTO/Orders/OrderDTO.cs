using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderDTO : DTOModelAbs<Order>
    {
      
        
        [ForClientOnly]
        public PersonContactDTO? PersonContact { get; set; }
      
        [HiddenFromClient]
        public int? PersonContactId { get; set; }



        [ForClientOnly]
        public CompanyDTO? Company { get; set; }

        [HiddenFromClient]
        public int? CompanyId { get; set; }






        public string Title { get; set; }
        public string? Description { get; set; }
        public CurrencyAndValueDTO Sum { get; set; }




        [ForClientOnly]
        public OrderSaleInfoDTO SaleInfo { get; set; }
    }
}
