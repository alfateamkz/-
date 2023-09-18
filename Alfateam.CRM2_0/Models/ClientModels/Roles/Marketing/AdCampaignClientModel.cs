using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing
{
	public class AdCampaignClientModel : ClientModel<AdCampaign>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public UserClientModel CampaignManager { get; set; }

		public AdCampaignStatus Status { get; set; }
	}
}
