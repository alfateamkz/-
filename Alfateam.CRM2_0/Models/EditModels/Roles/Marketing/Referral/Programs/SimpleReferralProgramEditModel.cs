using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing.Referral.Programs
{
	public class SimpleReferralProgramEditModel : BaseReferralProgramEditModel
	{
		/// <summary>
		/// Процент по реферальной программе
		/// </summary>
		public double Percent { get; set; }
	}
}
