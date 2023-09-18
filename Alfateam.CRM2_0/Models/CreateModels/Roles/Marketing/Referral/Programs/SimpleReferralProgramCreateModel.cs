using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing.Referral.Programs
{
	public class SimpleReferralProgramCreateModel : BaseReferralProgramCreateModel
	{
		/// <summary>
		/// Процент по реферальной программе
		/// </summary>
		public double Percent { get; set; }
	}
}
