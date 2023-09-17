using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts.Participants
{
	public class InfoConflictParticipantCreateModel : ConflictParticipantCreateModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }


		public int CountryId { get; set; }
	}
}
