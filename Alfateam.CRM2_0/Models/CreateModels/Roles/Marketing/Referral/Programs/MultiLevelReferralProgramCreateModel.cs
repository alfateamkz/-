using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing.Referral.Programs
{
	public class MultiLevelReferralProgramCreateModel : BaseReferralProgramCreateModel
	{
		public List<MultiLevelReferralProgramLevelCreateModel> Levels { get; set; } = new List<MultiLevelReferralProgramLevelCreateModel>();

		public override bool IsValid()
		{
			//TODO: MultiLevelReferralProgramCreateModel IsValid()
			return base.IsValid();
		}

		public override BaseReferralProgram Create()
		{
			//TODO: MultiLevelReferralProgramCreateModel Create()
			return base.Create();
		}
	}
}
