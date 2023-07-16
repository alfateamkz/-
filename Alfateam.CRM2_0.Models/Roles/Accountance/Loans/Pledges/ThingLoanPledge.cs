using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Loans.Pledges
{
    /// <summary>
    /// Модель вещевого залога
    /// </summary>
    public class ThingLoanPledge : LoanObligationPledge
    {
        public Currency Currency { get; set; }
        public double EstimatedCostForAll { get; set; }



        public Thing Thing { get; set; }
        public double Amount { get; set; }

    }
}
