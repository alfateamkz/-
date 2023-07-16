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
    /// Модель транспортного залога
    /// </summary>
    public class TransportLoanPledge : LoanObligationPledge
    {
        public Currency Currency { get; set; }
        public double EstimatedCost { get; set; }


        public Transport Transport { get; set; }

    }
}
