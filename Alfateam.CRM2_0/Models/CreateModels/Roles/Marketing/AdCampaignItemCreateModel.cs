using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing
{
	public class AdCampaignItemCreateModel : CreateModel<AdCampaignItem>
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public AdCampaignItemStatus Status { get; set; } = AdCampaignItemStatus.Planned;


		public string Title { get; set; }
		public string? Description { get; set; }
		public AdCampaignChannel Channel { get; set; }
		public List<int> CountriesIds { get; set; } = new List<int>();

		public override AdCampaignItem Create()
		{
			//TODO: реализовать AdCampaignItemCreateModel Create()
			var entity = base.Create();


			return entity;
		}

		public override bool IsValid()
		{
			//TODO: реализовать AdCampaignItemCreateModel IsValid()
			return base.IsValid();
		}
	}
}
