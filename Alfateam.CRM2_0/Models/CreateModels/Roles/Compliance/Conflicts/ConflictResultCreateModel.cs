using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts
{
	public class ConflictResultCreateModel : CreateModel<ConflictResult>
	{
		public string Description { get; set; }
	}
}
