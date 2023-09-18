using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing
{
	public class AdCampaignEditModel : EditModel<AdCampaign>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public int CampaignManagerId { get; set; }


		public AdCampaignStatus Status { get; set; }
	}
}
