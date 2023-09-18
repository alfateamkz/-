using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing
{
	public class AdCampaignBudgetItemCreateModel : CreateModel<AdCampaignBudgetItem>
	{
		public double Sum { get; set; }


		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
