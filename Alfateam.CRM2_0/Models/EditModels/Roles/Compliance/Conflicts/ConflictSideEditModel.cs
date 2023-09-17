using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts
{
	public class ConflictSideEditModel : EditModel<ConflictSide>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
