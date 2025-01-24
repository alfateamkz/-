using Alfateam.Core.Attributes.DTO;
using Alfateam.ID.Models.DTO.Abstractions;

namespace Alfateam.ID.Models.DTO.Payments.Ways
{
    public class BindedBankCardDTO : BindedPaymentWayDTO
    {
        [ForClientOnly]
        public string First6Digits { get; set; }

        [ForClientOnly]
        public string Last4Digits { get; set; }
    }
}
