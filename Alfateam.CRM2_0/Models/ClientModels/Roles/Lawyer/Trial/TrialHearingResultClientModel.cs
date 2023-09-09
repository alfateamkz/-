using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial
{
    public class TrialHearingResultClientModel : ClientModel<TrialHearingResult>
    {
        public TrialHearingResultType Type { get; set; }
        public string Description { get; set; }
		public bool IsLockedForChanges { get; set; }
	}
}
