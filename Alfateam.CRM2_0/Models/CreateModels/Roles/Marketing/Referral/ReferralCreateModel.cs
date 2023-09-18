using Alfateam.CRM2_0.Abstractions;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing.Referral
{
	public class ReferralCreateModel : CreateModel<Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Referral>
	{
		public int OwnerId { get; set; }
	}
}
