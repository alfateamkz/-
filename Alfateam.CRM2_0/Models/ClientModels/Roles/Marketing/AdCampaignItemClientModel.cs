using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing
{
	public class AdCampaignItemClientModel : ClientModel<AdCampaignItem>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public AdCampaignItemStatus Status { get; set; } = AdCampaignItemStatus.Planned;


		public string Title { get; set; }
		public string? Description { get; set; }
		public AdCampaignChannel Channel { get; set; }
		public List<CountryClientModel> Countries { get; set; } = new List<CountryClientModel>();
	}
}
