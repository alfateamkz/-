using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing
{
	public class AdCampaignItemReportCreateModel : CreateModel<AdCampaignItemReport>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
