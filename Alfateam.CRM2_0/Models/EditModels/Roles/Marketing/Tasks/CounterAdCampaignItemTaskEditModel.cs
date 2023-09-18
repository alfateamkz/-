using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Marketing.Tasks
{
	public class CounterAdCampaignItemTaskEditModel : BaseAdCampaignItemTaskEditModel
	{
		public double Total { get; set; }
		public double Completed { get; set; }
	}
}
