using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts
{
	public class ConflictResolutionProposalFeedbackCreateModel : CreateModel<ConflictResolutionProposalFeedback>
	{
		public int SideId { get; set; }
		public ConflictResolutionProposalFeedbackStatus Status { get; set; } = ConflictResolutionProposalFeedbackStatus.Approved;
		public string? Comment { get; set; }
	}
}
