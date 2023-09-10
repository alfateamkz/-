using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial
{
	public class TrialProcessSideEditModel : EditModel<TrialProcessSide>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
