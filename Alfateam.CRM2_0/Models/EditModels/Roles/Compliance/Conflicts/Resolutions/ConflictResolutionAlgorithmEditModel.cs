using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts.Resolutions
{
	public class ConflictResolutionAlgorithmEditModel : EditModel<ConflictResolutionAlgorithm>
	{
		public string Title { get; set; }
		public string Description { get; set; }

	}
}
