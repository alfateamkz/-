using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance
{
	public abstract class ConflictParticipantCreateModel : CreateModel<ConflictParticipant>
	{
		/// <summary>
		/// Может ли участник конфликта давать предложения и принимать решения от лица стороны конфликта
		/// Если в стороне конфликта только один человек, то по умолчанию равно true
		/// </summary>
		public bool IsLeader { get; set; }

		/// <summary>
		/// Комментарий об участнике конфликта
		/// </summary>
		public string? Comment { get; set; }
	}
}
