using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts.Resolutions
{
	public class ConflictResolutionAlgorithmBlockClientModel : ClientModel<ConflictResolutionAlgorithmBlock>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public ConflictResolutionAlgorithmBlockType Type { get; set; }

		/// <summary>
		/// Ветвления алгоритма
		/// </summary>
		public List<ConflictResolutionAlgorithmBlockClientModel> Nodes { get; set; } = new List<ConflictResolutionAlgorithmBlockClientModel>();
	}
}
