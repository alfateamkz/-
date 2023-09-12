using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption.Participants
{
    public class CRMBindedCorruptionCaseParticipantClientModel : CorruptionCaseParticipantClientModel
    {
        public UserClientModel Person { get; set; }
    }
}
