using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderStatusDTO : DTOModelAbs<OrderStatus>
    {
        public string Title { get; set; }




        [ForClientOnly]
        public bool IsDefault => BusinessCompanyId == null;


        [ForClientOnly]
        [Description("Автоматическое поле, не равно null, если статус создан пользователем (кастомный).\r\n" +
            "В таком случае Type будет равен OrderStatusType.Custom")]
        public int? BusinessCompanyId { get; set; }
    }
}
