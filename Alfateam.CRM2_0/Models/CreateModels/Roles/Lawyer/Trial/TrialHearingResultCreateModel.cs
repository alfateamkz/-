using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial
{
	public class TrialHearingResultCreateModel : CreateModel<TrialHearingResult>
	{
		public TrialHearingResultType Type { get; set; } = TrialHearingResultType.LawsuitApproved;
		public string Description { get; set; }
	}
}
