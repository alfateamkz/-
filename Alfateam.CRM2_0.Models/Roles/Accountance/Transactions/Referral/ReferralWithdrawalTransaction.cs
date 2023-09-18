using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions.Referral
{
	public class ReferralWithdrawalTransaction : Transaction
	{
		public string ToAccountInfo { get; set; }
	}
}
