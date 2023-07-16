using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.InvestProject
{
    /// <summary>
    /// Транзакция получения инвестиции на инвестиционный проект
    /// </summary>
    public class AdmissionInvestProjectTransaction : InvestProjectTransaction
    {
        public User FromInvestor { get; set; }
    }
}
