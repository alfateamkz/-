using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial.Participants
{
	public class InfoTrialProcessParticipantClientModel : TrialProcessParticipantClientModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }

		public CountryClientModel Country { get; set; }
	}
}
