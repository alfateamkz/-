using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial
{
	public class TrialRequestEditModel : EditModel<TrialRequest>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public TrialRequestType Type { get; set; } 
		public TrialRequestStatus Status { get; set; }
	}
}
