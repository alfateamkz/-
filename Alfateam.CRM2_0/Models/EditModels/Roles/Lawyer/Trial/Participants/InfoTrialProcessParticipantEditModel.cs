using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Lawyer;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial.Participants
{
	public class InfoTrialProcessParticipantEditModel : TrialProcessParticipantEditModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }


		public int CountryId { get; set; }
	}
}
