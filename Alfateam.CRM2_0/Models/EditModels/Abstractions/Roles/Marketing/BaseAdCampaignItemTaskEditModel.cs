using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing
{
	public abstract class BaseAdCampaignItemTaskEditModel : EditModel<BaseAdCampaignItemTask>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public AdCampaignItemTaskStatus Status { get; set; }
	}
}
