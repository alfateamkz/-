using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing.Referral
{
	public class MultiLevelReferralProgramLevelEditModel : EditModel<MultiLevelReferralProgramLevel>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public double Percent { get; set; }
	}
}
