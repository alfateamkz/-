using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing
{
	public class BaseReferralProgramEditModel : EditModel<BaseReferralProgram>
	{
		public string Title { get; set; }
		public string Description { get; set; }

		/// <summary>
		/// Минимальный лимит на вывод средств
		/// </summary>
		public double MinLimit { get; set; }
	}
}
