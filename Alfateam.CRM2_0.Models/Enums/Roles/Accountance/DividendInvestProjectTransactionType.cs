using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Accountance
{
    public enum DividendInvestProjectTransactionType
    {
        DepositDividends = 1, //Выплата основного вклада-инвестиции
        DepositWithdrawal = 2, //Выплата процентов по вкладу-инвестиции
        EquityDividends = 3 //Выплата доли от дохода/выручки
    }
}
