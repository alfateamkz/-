using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts.Participants
{
	public class InfoConflictParticipantClientModel : ConflictParticipantClientModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }


		public CountryClientModel Country { get; set; }
	}
}
