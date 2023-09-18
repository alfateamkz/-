using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing
{
	public class AdCampaignItemTaskCheckRequestResultCreateModel : CreateModel<AdCampaignItemTaskCheckRequestResult>
	{
		public AdCampaignItemTaskStatus Status { get; set; }
		public string? Comment { get; set; }
	}
}
