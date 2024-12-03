using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main.Transactions
{
    public class WithdrawalReferralAccountTransaction : ReferralAccountTransaction
    {
        public WithdrawalReferralAccountTransactionStatus Status { get; set; }
        public string ToAccountBankInfo { get; set; }
        public string ChequeFilepath { get; set; }
    }
}
