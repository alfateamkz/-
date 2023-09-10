using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial
{
	public class TrialProcessResultCreateModel : CreateModel<TrialProcessResult>
	{
		public string Description { get; set; }
	}
}
