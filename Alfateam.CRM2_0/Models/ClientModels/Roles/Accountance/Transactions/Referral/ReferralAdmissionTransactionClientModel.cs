using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Staff;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance.Transactions.Referral
{
	public class ReferralAdmissionTransactionClientModel : TransactionClientModel
	{
		public BaseReferralProgramClientModel Program { get; set; }
		public OrderClientModel Order { get; set; }
	}
}
