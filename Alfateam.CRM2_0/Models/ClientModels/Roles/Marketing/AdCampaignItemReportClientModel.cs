using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing
{
	public class AdCampaignItemReportClientModel : ClientModel<AdCampaignItemReport>
	{
		public UserClientModel CreatedBy { get; set; }


		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
