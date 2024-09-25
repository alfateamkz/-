using Alfateam.Core.Attributes.DTO;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Payments;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.ID.API.Models.DTO.Payments
{
    public class PaymentDTO : DTOModelAbs<Payment>
    {
        [ForClientOnly]
        public PaymentStatus Status { get; set; }
        [ForClientOnly]
        public DateTime? PaidAt { get; set; }


        [ForClientOnly]
        public string CurrencyCode { get; set; }
        [ForClientOnly]
        public decimal Sum { get; set; }
        [ForClientOnly]
        public string Comment { get; set; }
    }
}
