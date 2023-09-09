using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
	public class TrialProcessResultClientModel : ClientModel<TrialProcessResult>
	{
		public string Description { get; set; }
	}
}
