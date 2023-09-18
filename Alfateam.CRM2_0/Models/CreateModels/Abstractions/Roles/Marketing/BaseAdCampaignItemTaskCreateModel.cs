using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Marketing
{
	public abstract class BaseAdCampaignItemTaskCreateModel : CreateModel<BaseAdCampaignItemTask>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }


		public List<BaseAdCampaignItemTaskCreateModel> SubTasks { get; set; } = new List<BaseAdCampaignItemTaskCreateModel>();

		public override BaseAdCampaignItemTask Create()
		{
			//TODO: доработать BaseAdCampaignItemTask Create()
			return base.Create();
		}
		public override void Fill(BaseAdCampaignItemTask item)
		{
			//TODO: доработать Fill(BaseAdCampaignItemTask item)
			base.Fill(item);
		}

	}
}
