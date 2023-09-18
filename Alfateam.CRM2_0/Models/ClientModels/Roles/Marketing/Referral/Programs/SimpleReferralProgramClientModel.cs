using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing.Referral.Programs
{
	public class SimpleReferralProgramClientModel : BaseReferralProgramClientModel
	{
		/// <summary>
		/// Процент по реферальной программе
		/// </summary>
		public double Percent { get; set; }
	}
}
