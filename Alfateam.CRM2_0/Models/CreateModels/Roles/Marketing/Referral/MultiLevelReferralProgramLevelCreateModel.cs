using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing.Referral
{
	public class MultiLevelReferralProgramLevelCreateModel : CreateModel<MultiLevelReferralProgramLevel>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public double Percent { get; set; }
	}
}
