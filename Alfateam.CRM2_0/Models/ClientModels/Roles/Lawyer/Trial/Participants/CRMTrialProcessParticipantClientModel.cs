using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial.Participants
{
	public class CRMTrialProcessParticipantClientModel : TrialProcessParticipantClientModel
	{
		public UserClientModel User { get; set; }
	}
}
