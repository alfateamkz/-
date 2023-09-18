using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing
{
	public class AdCampaignItemEditModel : EditModel<AdCampaignItem>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public AdCampaignItemStatus Status { get; set; } = AdCampaignItemStatus.Planned;


		public string Title { get; set; }
		public string? Description { get; set; }
		public AdCampaignChannel Channel { get; set; }
		public List<int> CountriesIds { get; set; } = new List<int>();

	}
}
