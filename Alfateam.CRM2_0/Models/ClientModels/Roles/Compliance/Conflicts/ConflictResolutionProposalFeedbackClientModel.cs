using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts
{
	public class ConflictResolutionProposalFeedbackClientModel : ClientModel<ConflictResolutionProposalFeedback>
	{
		public ConflictSideClientModel Side { get; set; }
		public ConflictResolutionProposalFeedbackStatus Status { get; set; }

		public string? Comment { get; set; }
	}
}
