using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts
{
	public class ConflictResolutionProposalFeedbackEditModel : EditModel<ConflictResolutionProposalFeedback>
	{
		public ConflictResolutionProposalFeedbackStatus Status { get; set; }
		public string? Comment { get; set; }
	}
}
