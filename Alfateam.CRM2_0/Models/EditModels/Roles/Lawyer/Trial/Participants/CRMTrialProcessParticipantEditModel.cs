using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Lawyer;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial.Participants
{
	public class CRMTrialProcessParticipantEditModel : TrialProcessParticipantEditModel
	{
		public int UserId { get; set; }
	}
}
