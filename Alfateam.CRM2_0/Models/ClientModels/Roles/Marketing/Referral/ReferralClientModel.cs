using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing.Referral
{
	public class ReferralClientModel : ClientModel<Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Referral>
	{
		public UserClientModel Owner { get; set; }


		/// <summary>
		/// Привлеченные рефералы
		/// </summary>
		public List<ReferralClientModel> Referrals { get; set; } = new List<ReferralClientModel>();



		/// <summary>
		/// Реферальные валютные счета 
		/// </summary>
		public List<AccountClientModel> Accounts { get; set; } = new List<AccountClientModel>();
	}
}
