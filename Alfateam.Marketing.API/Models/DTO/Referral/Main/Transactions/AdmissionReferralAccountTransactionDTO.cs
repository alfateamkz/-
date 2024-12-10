using Alfateam.Marketing.API.Models.DTO.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Main.Transactions
{
    public class AdmissionReferralAccountTransactionDTO : ReferralAccountTransactionDTO
    {
        public string ExtOrderId { get; set; }
        public string OrderInfo { get; set; }
    }
}
