using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts.Resolutions
{
	public class ConflictResolutionAlgorithmClientModel : ClientModel<ConflictResolutionAlgorithm>
	{
		public string Title { get; set; }
		public string Description { get; set; }


		/// <summary>
		/// Начало алгоритма урегулирования конфликта
		/// </summary>
		public ConflictResolutionAlgorithmBlockClientModel StartBlock { get; set; }
	}
}
