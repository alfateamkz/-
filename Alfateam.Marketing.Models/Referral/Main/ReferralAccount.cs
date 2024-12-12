using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Referral.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main
{
    public class ReferralAccount : AbsModel
    {
        public string CurrencyCode { get; set; }
        public List<ReferralAccountTransaction> Transactions { get; set; } = new List<ReferralAccountTransaction>();


        public decimal GetBalance()
        {
            decimal balance = 0;

            foreach(var transaction in Transactions)
            {
                if(transaction is AdmissionReferralAccountTransaction admission)
                {
                    balance += transaction.Value;
                }
                else if (transaction is WithdrawalReferralAccountTransaction withdrawal)
                {
                    balance -= withdrawal.Value;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return balance;
        }

        public decimal GetBlockedSum()
        {
            decimal sum = 0;

            foreach (var transaction in Transactions.Where(o => o is WithdrawalReferralAccountTransaction).Cast<WithdrawalReferralAccountTransaction>())
            {
                if(transaction.Status == WithdrawalReferralAccountTransactionStatus.InProcessing)
                {
                    sum += transaction.Value;
                }
            }

            return sum;
        }
    }
}
