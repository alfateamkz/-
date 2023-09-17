using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts
{
	public class ConflictResultClientModel : ClientModel<ConflictResult>
	{
		public string Description { get; set; }
		public List<ConflictResultActionClientModel> Actions { get; set; } = new List<ConflictResultActionClientModel>();
	}
}
