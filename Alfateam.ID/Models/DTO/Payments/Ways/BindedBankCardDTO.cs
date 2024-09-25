using Alfateam.Core.Attributes.DTO;
using Alfateam.ID.API.Abstractions.DTO;

namespace Alfateam.ID.API.Models.DTO.Payments.Ways
{
    public class BindedBankCardDTO : BindedPaymentWayDTO
    {
        [ForClientOnly]
        public string First6Digits { get; set; }
        [ForClientOnly]
        public string Last4Digits { get; set; }
        [ForClientOnly]
        public string Token { get; set; }
    }
}
