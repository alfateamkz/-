using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing.Referral.Programs
{
	public class MultiLevelReferralProgramClientModel : BaseReferralProgramClientModel
	{
		public List<MultiLevelReferralProgramLevelClientModel> Levels { get; set; } = new List<MultiLevelReferralProgramLevelClientModel>();
	}
}
