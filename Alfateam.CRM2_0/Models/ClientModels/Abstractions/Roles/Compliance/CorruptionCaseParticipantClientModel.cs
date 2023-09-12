using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance
{
    public abstract class CorruptionCaseParticipantClientModel : ClientModel<CorruptionCaseParticipant>
    {
        public string Comment { get; set; }
    }
}
