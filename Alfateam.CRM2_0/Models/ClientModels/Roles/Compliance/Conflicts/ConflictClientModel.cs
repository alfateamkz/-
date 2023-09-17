using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts
{
	public class ConflictClientModel : ClientModel<Conflict>
	{
		public string Title { get; set; }
		public string Description { get; set; }


		public ConflictStatus Status { get; set; }


		public ConflictResultClientModel? Result { get; set; }

	}
}
