using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Sales.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.Referral
{
    public class ReferralAdmissionTransaction : Transaction
    {
        public BaseReferralProgram Program { get; set; }
		public int ProgramId { get; set; }


		public Order Order { get; set; }
		public int OrderId { get; set; }
	}
}
