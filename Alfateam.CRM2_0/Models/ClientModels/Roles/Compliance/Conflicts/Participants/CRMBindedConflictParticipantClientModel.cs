using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts.Participants
{
	public class CRMBindedConflictParticipantClientModel : ConflictParticipantClientModel
	{
		public UserClientModel User { get; set; }
	}
}
