using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing.Tasks
{
	public class CounterAdCampaignItemTaskClientModel : BaseAdCampaignItemTaskClientModel
	{
		public double Total { get; set; }
		public double Completed { get; set; }
	}
}
