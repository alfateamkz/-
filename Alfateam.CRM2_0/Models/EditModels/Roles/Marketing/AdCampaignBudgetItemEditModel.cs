using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing
{
	public class AdCampaignBudgetItemEditModel : EditModel<AdCampaignBudgetItem>
	{
		public double Sum { get; set; }


		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
