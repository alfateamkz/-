using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Lawyer;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial.Participants
{
	public class InfoTrialProcessParticipantCreateModel : TrialProcessParticipantCreateModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }


		public int CountryId { get; set; }
	}
}
