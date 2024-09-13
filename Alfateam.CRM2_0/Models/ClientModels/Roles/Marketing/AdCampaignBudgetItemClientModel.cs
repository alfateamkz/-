using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing
{
	public class AdCampaignBudgetItemClientModel : ClientModel<AdCampaignBudgetItem>
	{
        public CurrencyClientModel Currency { get; set; }
        public double Sum { get; set; }


		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
