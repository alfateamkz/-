using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts
{
	public class ConflictResultActionCreateModel : CreateModel<ConflictResultAction>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public DateTime Deadline { get; set; }
		public ConflictResultActionStatus Status { get; set; } = ConflictResultActionStatus.NotPerformed;
	}
}
