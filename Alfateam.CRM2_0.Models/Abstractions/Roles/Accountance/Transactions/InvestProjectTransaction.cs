using Alfateam.CRM2_0.Models.Roles.Financier.Investments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions
{
    /// <summary>
    /// Базовая модель транзакции с привязкой к инвест проекту
    /// </summary>
    public abstract class InvestProjectTransaction : Transaction
    {
        public InvestProject Project { get; set; }

    }
}
