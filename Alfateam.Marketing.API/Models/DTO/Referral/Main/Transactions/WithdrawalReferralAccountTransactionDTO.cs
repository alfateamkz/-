using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.Models.Enums;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Main.Transactions
{
    public class WithdrawalReferralAccountTransactionDTO : ReferralAccountTransactionDTO
    {
        public WithdrawalReferralAccountTransactionStatus Status { get; set; }
        public string ToAccountBankInfo { get; set; }
        public string ChequeFilepath { get; set; }
    }
}
