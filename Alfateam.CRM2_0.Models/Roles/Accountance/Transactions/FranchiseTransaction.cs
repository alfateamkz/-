using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Sales.Franchising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions
{
    /// <summary>
    /// Транзакция с привязкой к франшизе
    /// </summary>
    public class FranchiseTransaction : Transaction
    {
        public FranchiseSale Franchise { get; set; }
        public FranchiseTransactionType Type { get; set; } = FranchiseTransactionType.EntryFee;
    }
}
