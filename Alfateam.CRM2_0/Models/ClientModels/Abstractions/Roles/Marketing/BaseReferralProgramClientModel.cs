using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing
{
	public class BaseReferralProgramClientModel : ClientModel<BaseReferralProgram>
	{
		public string Title { get; set; }
		public string Description { get; set; }

		/// <summary>
		/// Минимальный лимит на вывод средств
		/// </summary>
		public double MinLimit { get; set; }




		/// <summary>
		/// Чисто инкремент для того, чтобы каждый раз не вычислять кол-во
		/// </summary>
		public int ReferralsCount { get; set; }
	}
}
