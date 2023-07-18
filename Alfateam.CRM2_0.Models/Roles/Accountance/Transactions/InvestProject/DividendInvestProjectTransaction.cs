using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject
{
    /// <summary>
    /// Транзакция выплаты дивидендов по инвестиции с инвестиционного проекта
    /// </summary>
    public class DividendInvestProjectTransaction : InvestProjectTransaction
    {
        public InvestProjectDeposit From { get; set; }
        public DividendInvestProjectTransactionType Type { get; set; } = DividendInvestProjectTransactionType.DepositWithdrawal;
    }
}
