using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts
{
	public class ConflictSideClientModel : ClientModel<ConflictSide>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}
