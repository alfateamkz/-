using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial.Participants
{
	public class CRMTrialProcessParticipantCreateModel : TrialProcessParticipantCreateModel
	{
		public int UserId { get; set; }
	}
}
